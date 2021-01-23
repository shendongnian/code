    public FrmAdmin()
    {
        InitializeComponent();
        IsMdiContainer = true;
    }
    GameList gamelist = new GameList();
    gamelist.MdiParent = this;
    gamelist.WindowState = FormWindowState.Maximized;
    gamelist.Show();
 
