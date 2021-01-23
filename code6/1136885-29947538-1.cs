    class Program
    {
        [DllImport("Kernel32")]
        public static extern void AllocConsole();
        [DllImport("Kernel32")]
        public static extern void FreeConsole();
        [DllImport("kernel32.dll")]
        static extern bool AttachConsole(uint dwProcessId);
        [STAThread]
        public static void Main(string[] args)
        {
            bool madeConsole = false;
            if (args.Length > 0 && args[0] == "console")
            {
                if (!AttachToConsole())
                {
                    AllocConsole();
                    Console.WriteLine("Had to create a console");
                    madeConsole = true;
                }
                Console.WriteLine("Now I'm a console app!");
                Console.WriteLine("Press any key to exit");
                Console.ReadKey(true);
                if (madeConsole)
                    FreeConsole();
            }
            else
            {
                WpfApplication1.App.Main();
            }
        }
        
        public static bool AttachToConsole()
        {
            const uint ParentProcess = 0xFFFFFFFF;
            if (!AttachConsole(ParentProcess))
                return false;
            Console.Clear();
            Console.WriteLine("Attached to console!");
            return true;
        }
    }
