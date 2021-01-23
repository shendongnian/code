        static class Program {
            static bool formClosed = false;
            [STAThread]
            static void Main() {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Form1 form = new Form1();
                form.Show();
                form.FormClosed += Form_FormClosed;
                while(!formClosed) {
                    Application.DoEvents();
                    Thread.Sleep(100);
                }
            }
            private static void Form_FormClosed(object sender, FormClosedEventArgs e) { 
                formClosed = true; }
    }
