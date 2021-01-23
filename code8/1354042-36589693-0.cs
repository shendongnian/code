    public frmMain()
    {
        new VisualStudio2012LightTheme();
        InitializeComponent();
        this.ThemeName = "VisualStudio2012Light";
    }
    private void frmMain_Shown(object sender, EventArgs e)
    {
        this.FormElement.TitleBar.ForeColor = Color.White;
    }
