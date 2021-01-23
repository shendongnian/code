        public static ABCDE form;
        public static BCI1 form1;
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            form = new ABCDE();
            form1 = new BCI1();
            form.Show();
            form1.Show();
            Application.Idle += new EventHandler(Application_Idle);
            Application.Run();
        }
        static void Application_Idle(object sender, EventArgs e)
        {
            Message message;
            while (!PeekMessage(out message, IntPtr.Zero, 0, 0, 0))
            {
                form.UpdateFrame();
                form1.UpdateFrame();
            }
        }
