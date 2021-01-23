    public static int i=2;
    public ChildWindow()
    {
        InitializeComponent();
        ParentWindow.i=2;
    }
    
    private void Child_FormClosing(object sender, FormClosingEventArgs e)
    {
        if (i==3)
        {               
            Application.Exit();
        }
        ParentWindow.i = 4;
    }
