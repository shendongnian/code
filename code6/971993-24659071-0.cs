        [STAThread]
        static void Main() {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            // Application.Run(new Form1());   Not this anymore
            var window = new Form1();
            window.Show();
            // Your game loop here
            //...
        }
