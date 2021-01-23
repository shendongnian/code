        ...
        [DllImport("kernel32.dll")]
        static extern bool AttachConsole(int input);
        static void Main(string[] args)
        {            
            if (args.Length == 0)
            {   
                Application.Run(new MyForm());
            }
            else if (args.Length == 1)
            {
                AttachConsole(-1);
                Console.WriteLine("Console party");
        ...
