    static void Main()
    {
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
        for (int i = 0; i < 15; i++)
        {
            new Form1().Show();
            Thread.Sleep(100);
        }
        // code exit's here, thus closing all forms created.
    }
