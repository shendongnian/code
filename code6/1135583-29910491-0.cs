        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles(); // Did you remove this line?
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
