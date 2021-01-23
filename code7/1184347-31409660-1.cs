    [STAThread]
    static void Main()
    {
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
    //    Application.Run(new Form1());  <-- This is the usual startup
    
        // Instead, do this to grab an object to invoke on
        Form1 form1 = new Form1();
        _invoker = form1;
        Application.Run(form1);
    }
