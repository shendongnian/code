    using System.Diagnostics;
    ...
        [STAThread]
        static void Main() {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            var main = new Form1();
            switch (Process.GetCurrentProcess().StartInfo.WindowStyle) {
                case ProcessWindowStyle.Minimized: main.WindowState = FormWindowState.Minimized; break;
                case ProcessWindowStyle.Maximized: main.WindowState = FormWindowState.Maximized; break;
            }
            Application.Run(main);
        }
