    using System.Runtime.InteropServices;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace ConsoleApplication1
    {
        class Program
        {
    
            static void Main(string[] args)
            {
                HandlerRoutine hr = new HandlerRoutine(InspectControlType);
                SetConsoleCtrlHandler(hr, true);
                Console.WriteLine("Click on Windows Close Button");
                Console.ReadLine();
    
            }
    
            [DllImport("Kernel32")]
            public static extern bool SetConsoleCtrlHandler(HandlerRoutine Handler, bool Add);
    
            public delegate bool HandlerRoutine(ControlTypes CtrlType);
    
            public enum ControlTypes
            {
                CTRL_C_EVENT = 0,
                CTRL_BREAK_EVENT,
                CTRL_CLOSE_EVENT,
                CTRL_LOGOFF_EVENT = 5,
                CTRL_SHUTDOWN_EVENT
            }
    
            private static bool InspectControlType(ControlTypes ctrlType)
            {
                Console.WriteLine("Hello You choose to end this program.Do you really want to close? :" + ctrlType.ToString());
                Console.ReadLine();
                return true;
            }
    
    
        }
    }
