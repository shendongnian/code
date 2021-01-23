    using System.Threading;
    using System.Runtime.InteropServices;
    // Add reference for VISA-COM 5.9 Type Library
    using Ivi.Visa.Interop;
    namespace USBCommunications
    {
        class Program
        {
            static void Main(string[] args)
            {
                Gpib.Write(address: 5, command: "*IDN?");
                bool success = Gpib.Read(address: 5, valueRead: out string valueRead);
                System.Console.WriteLine($"The ID is {valueRead}");
                System.Console.ReadLine();
            }
        }
        public class Gpib
        {
            static ResourceManager resourceManager;
            static FormattedIO488 ioObject;
            public static bool Write(byte address, string command)
            {
                resourceManager = new ResourceManager();
                ioObject = new FormattedIO488();
                string addr = $"GPIB::{address.ToString()}::INSTR";
                try
                {
                    ioObject.IO = (IMessage)resourceManager.Open(addr, AccessMode.NO_LOCK, 0, "");
                    Thread.Sleep(20);
                    ioObject.WriteString(data: command, flushAndEND: true);
                    return true;
                }
                catch
                {
                    return false;
                }
                finally
                {
                    try { ioObject.IO.Close(); }
                    catch { }
                    try { Marshal.ReleaseComObject(ioObject); }
                    catch { }
                    try { Marshal.ReleaseComObject(resourceManager); }
                    catch { }
                }
            }
            public static bool Read(byte address, out string valueRead)
            {
                resourceManager = new ResourceManager();
                ioObject = new FormattedIO488();
                string addr = $"GPIB::{address.ToString()}::INSTR";
                try
                {
                    ioObject.IO = (IMessage)resourceManager.Open(addr, AccessMode.NO_LOCK, 0, "");
                    Thread.Sleep(20);
                    valueRead = ioObject.ReadString();
                    return true;
                }
                catch
                {
                    valueRead = "";
                    return false;
                }
                finally
                {
                    try { ioObject.IO.Close(); }
                    catch { }
                    try { Marshal.ReleaseComObject(ioObject); }
                    catch { }
                    try { Marshal.ReleaseComObject(resourceManager); }
                    catch { }
                }
            }
        }
    }
