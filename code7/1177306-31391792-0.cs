        private static object SyncRoot = new object();
        static string returnValue = null;
        
        [ServiceContract]
        public interface IGetChromeString
        {
            [OperationContract]
            string GetString(string value);
        }
        public class CGetChromeString : IGetChromeString
        {
            public string GetString(string value)
            {
                OpenStandardStreamOut(value);
                // Wait until OpenStandardStreamIn() sets returnValue in the Main Thread
                lock (SyncRoot)
                {
                    Monitor.Wait(SyncRoot);
                }
                return returnValue;
            }
        }
        static void Main(string[] args)
        {
            using (ServiceHost host = new ServiceHost(typeof(CGetChromeString), new Uri[] { new Uri("net.pipe://localhost") }))
            {
                host.AddServiceEndpoint(typeof(IGetChromeString), new NetNamedPipeBinding(), "PipeReverse");
                host.Open();
                while (returnValue != "")
                {
                    returnValue = OpenStandardStreamIn();
                    // returnValue has been set, GetUrl can resume.
                    lock (SyncRoot)
                    {
                        Monitor.Pulse(SyncRoot);
                    }
                }
                host.Close();
            }
        }
        static string OpenStandardStreamIn()
        {
            Stream stdin = Console.OpenStandardInput();
            byte[] bytes = new byte[4];
            stdin.Read(bytes, 0, 4);
            int length = 0;
            length = System.BitConverter.ToInt32(bytes, 0);
            string input = "";
            for (int i = 0; i < length; i++)
            {
                input += (char)stdin.ReadByte();
            }
            return input;
        }
        static void OpenStandardStreamOut(string stringData)
        {
            string msgdata = "{\"text\":\"" + stringData + "\"}";
            int DataLength = msgdata.Length;
            Stream stdout = Console.OpenStandardOutput();
            stdout.WriteByte((byte)((DataLength >> 0) & 0xFF));
            stdout.WriteByte((byte)((DataLength >> 8) & 0xFF));
            stdout.WriteByte((byte)((DataLength >> 16) & 0xFF));
            stdout.WriteByte((byte)((DataLength >> 24) & 0xFF));
            Console.Write(msgdata);
        }
