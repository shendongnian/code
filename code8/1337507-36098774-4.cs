    static void Main()
    {
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
        for (int i = 0; i < 14; i++) // <- note 14
        {
            new Form1().Show(); // will show the form
            Thread.Sleep(100);
        }
        // This will show the form and block until the form is closed
        Application.Run(new Form1());
    }
