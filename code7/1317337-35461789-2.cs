    public Form1()
    {
        InitializeComponent();
        this.HelpRequested += onHelpRequested;
        .....
    }
    protected void onHelpRequested(object sender, HelpEventArgs e)
    {
        e.Handled = true;
    }
