    public  MainForm()
    {
      InitializeComponent();
      main = this;
    }
    internal static MainForm main;
    internal string Status
    {
        get { return dataTextBox.Text.ToString(); }
        set { dataTextBox.Text = value; }
    }
