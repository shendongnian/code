    public Form1()
    {
        InitializeComponent();
        Second_Button.Click += ButtonClick;
        First_Button.Click += ButtonClick;
    }
    private void ButtonClick(object sender, EventArgs e)
    {
        var directory = String.Empty;
        Button clickedButton = (Button)sender;
        switch (clickedButton.Name)
        {
            case "First_Button":
                directory = _ftp.GetCurrentDate(true);
                break;
            case "Second_Button":
                directory = _ftp.GetCurrentDate(false);
                break;
            case null:
                return;
        }
    
        First_Button.Enabled = false;
        Second_Button.Enabled = false;
        var bw = new BackgroundWorker();
        bw.DoWork += (o, args) =>
        {
            // your work. You can use directory here
        };
        bw.RunWorkerCompleted += (o, args) =>
        {
            First_Button.Enabled = true;
            Second_Button.Enabled = true;
        };
        bw.RunWorkerAsync();
    
    }
