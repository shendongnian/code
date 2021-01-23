    namespace ConsoleApplication1
    {
        class programm
        {
            [DllImport("Tapi32.dll")]
            public static extern int tapiRequestMakeCall(string Number, 
                string AppName, string CalledParty, string Comment);
            
            static void Main(string[] args)
            {
            }
        }
    }
