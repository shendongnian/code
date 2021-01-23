    Form1 a = null;
    [STAThread]
    static void Main()
    {
       Application.EnableVisualStyles();
       Application.SetCompatibleTextRenderingDefault(false);
       a = new Form1();
       Application.Run(a);
    }
