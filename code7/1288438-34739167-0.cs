    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] argv)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            // if You run the program like "CommTest.exe 10010", than it will be host.
            // if You run it like "CommTest.exe localhost 10010", than it will be client connecting to localhost.
            if (argv.Length == 1)
            {
                Application.Run(new Form2(new Host(int.Parse(argv[0]))));
            }
            else
            {
                Application.Run(new Form1(new Client(argv[0], int.Parse(argv[1]))));
            }
        }
    }
