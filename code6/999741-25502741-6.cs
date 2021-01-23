    // complete example use this as Program.cs in a console application project
    namespace SystemDateManipulator101
    {
        using System;
        using System.Collections.Generic;
        using System.Linq;
        using System.Net;
        using System.Net.Sockets;
        using System.Runtime.InteropServices;
        using System.Text;
        using System.Threading;
        using System.Threading.Tasks;
    
        /// <summary>
        /// Program class.
        /// </summary>
        public class Program
        {
            #region Methods
    
            static void Main(string[] args)
            {
                // test one: set system time to a random time that is not near daylight savings time transition
                DateTime timeToSet = new DateTime(2014, 5, 5, 4, 59, 59, 0);
                Console.WriteLine("timeToSet Kind: {0}", timeToSet.Kind);
                Console.WriteLine("Attemting to set time to {0}", timeToSet);
                SetLocalSytemDateTime(timeToSet);
                Console.WriteLine("Now time is {0}, which is {1} (UTC)", DateTime.Now, DateTime.UtcNow);
                Thread.Sleep(TimeSpan.FromSeconds(5));
                DateTime actualSystemTime = GetNetworkTime();
                SetLocalSytemDateTime(actualSystemTime);
    
                Thread.Sleep(TimeSpan.FromSeconds(5));
    
                // test two: set system time to one second before transition to daylight savings time in Berlin
                timeToSet = new DateTime(2015, 3, 29, 1, 59, 59, 0);
                Console.WriteLine("timeToSet Kind: {0}", timeToSet.Kind);
                Console.WriteLine("Attemting to set time to {0}", timeToSet);
                SetLocalSytemDateTime(timeToSet);
                Console.WriteLine("Now time is {0}, which is {1} (UTC)", DateTime.Now, DateTime.UtcNow);
                Thread.Sleep(TimeSpan.FromSeconds(5));
                actualSystemTime = GetNetworkTime();
                SetLocalSytemDateTime(actualSystemTime);
    
                Thread.Sleep(TimeSpan.FromSeconds(5));
    
                // test three: set system time to one second before transition out of daylight savings time in Berlin
                timeToSet = new DateTime(2014, 10, 26, 2, 59, 59, 0);
                Console.WriteLine("timeToSet Kind: {0}", timeToSet.Kind);
                Console.WriteLine("Attemting to set time to {0}", timeToSet);
                SetLocalSytemDateTime(timeToSet);
                Console.WriteLine("Now time is {0}, which is {1} (UTC)", DateTime.Now, DateTime.UtcNow);
                Thread.Sleep(TimeSpan.FromSeconds(5));
                actualSystemTime = GetNetworkTime();
                SetLocalSytemDateTime(actualSystemTime);
    
                Console.Read();
            }
    
            #endregion
            
            // https://stackoverflow.com/a/12150289/162671
            public static DateTime GetNetworkTime()
            {
                //default Windows time server
                const string ntpServer = "time.windows.com";
    
                // NTP message size - 16 bytes of the digest (RFC 2030)
                var ntpData = new byte[48];
    
                //Setting the Leap Indicator, Version Number and Mode values
                ntpData[0] = 0x1B; //LI = 0 (no warning), VN = 3 (IPv4 only), Mode = 3 (Client Mode)
    
                var addresses = Dns.GetHostEntry(ntpServer).AddressList;
    
                //The UDP port number assigned to NTP is 123
                var ipEndPoint = new IPEndPoint(addresses[0], 123);
                //NTP uses UDP
                var socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
    
                socket.Connect(ipEndPoint);
    
                //Stops code hang if NTP is blocked
                socket.ReceiveTimeout = 3000;
    
                socket.Send(ntpData);
                socket.Receive(ntpData);
                socket.Close();
    
                //Offset to get to the "Transmit Timestamp" field (time at which the reply 
                //departed the server for the client, in 64-bit timestamp format."
                const byte serverReplyTime = 40;
    
                //Get the seconds part
                ulong intPart = BitConverter.ToUInt32(ntpData, serverReplyTime);
    
                //Get the seconds fraction
                ulong fractPart = BitConverter.ToUInt32(ntpData, serverReplyTime + 4);
    
                //Convert From big-endian to little-endian
                intPart = SwapEndianness(intPart);
                fractPart = SwapEndianness(fractPart);
    
                var milliseconds = (intPart * 1000) + ((fractPart * 1000) / 0x100000000L);
    
                //**UTC** time
                var networkDateTime = (new DateTime(1900, 1, 1, 0, 0, 0, DateTimeKind.Utc)).AddMilliseconds((long)milliseconds);
    
                return networkDateTime.ToLocalTime();
            }
    
            // stackoverflow.com/a/3294698/162671
            static uint SwapEndianness(ulong x)
            {
                return (uint)(((x & 0x000000ff) << 24) +
                               ((x & 0x0000ff00) << 8) +
                               ((x & 0x00ff0000) >> 8) +
                               ((x & 0xff000000) >> 24));
            }
    
            [StructLayout(LayoutKind.Sequential)]
            public struct SYSTEMTIME
            {
                public short wYear;
                public short wMonth;
                public short wDayOfWeek;
                public short wDay;
                public short wHour;
                public short wMinute;
                public short wSecond;
                public short wMilliseconds;
            }
    
            [DllImport("kernel32.dll", SetLastError = true)]
            public static extern bool SetSystemTime(ref SYSTEMTIME st);
    
            [DllImport("kernel32.dll", SetLastError = true)]
            public static extern bool SetLocalTime(ref SYSTEMTIME st);
            
            public static void SetSystemDateTime(DateTime timeToSet)
            {
                DateTime uniTime = timeToSet.ToUniversalTime();
                SYSTEMTIME setTime = new SYSTEMTIME()
                {
                    wYear = (short)uniTime.Year,
                    wMonth = (short)uniTime.Month,
                    wDay = (short)uniTime.Day,
                    wHour = (short)uniTime.Hour,
                    wMinute = (short)uniTime.Minute,
                    wSecond = (short)uniTime.Second,
                    wMilliseconds = (short)uniTime.Millisecond
                };
    
                SetSystemTime(ref setTime);
            }
    
            public static void SetLocalSytemDateTime(DateTime timeToSet)
            {
                SYSTEMTIME setTime = new SYSTEMTIME()
                {
                    wYear = (short)timeToSet.Year,
                    wMonth = (short)timeToSet.Month,
                    wDay = (short)timeToSet.Day,
                    wHour = (short)timeToSet.Hour,
                    wMinute = (short)timeToSet.Minute,
                    wSecond = (short)timeToSet.Second,
                    wMilliseconds = (short)timeToSet.Millisecond
                };
    
                SetLocalTime(ref setTime);
                // yes this second call is really necessary, because the system uses the daylight saving time setting of the current time, not the new time you are setting
                // http://msdn.microsoft.com/en-us/library/windows/desktop/ms724936%28v=vs.85%29.aspx
                SetLocalTime(ref setTime);
            }
        }
    }
