    namespace ConsoleApplication1
    {
        class Program
        {
            namespace SysWin32
            {
                class programm
                {
                    [DllImport("Tapi32.dll")]
                    public static extern long tapiRequestMakeCall(string Number, 
                        string AppName, string CalledParty, string Comment);
                }
    
            }
            
            static void Main(string[] args)
            {
            }
        }
    }
