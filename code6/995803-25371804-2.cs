    public Form1()
    {
        InitializeComponent();
        CustomUserControl.ButtonClick += UserControlButtonClickHandler();
    }
    private void UserControlButtonClickHandler(object sender, EventArgs e)
    {
        // add the value here
    }
