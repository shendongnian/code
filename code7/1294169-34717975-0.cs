    public FrmAdmin()
    {
        InitializeComponent();
        IsMdiContainer = true;
    }
    GameList gamelist = new GameList();// the form which I want to open
    gamelist.MdiParent = this;
    gamelist.WindowState = FormWindowState.Maximized;
    gamelist.Show();
 
