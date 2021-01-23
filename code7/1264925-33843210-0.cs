    public void Run()
    {
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(true);
        IsRunning = true;
        this.Initialize();
        MyForm = new CoolRenderForm();
        MyForm.Show();
        while (IsRunning)
        {
            Render(/* arguments here */);
            Application.DoEvents();
            // refresh form
            // pausing and stuff
        }
        Dispose();
    }
