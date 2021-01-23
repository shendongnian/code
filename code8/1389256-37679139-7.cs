    static RadioCtl RbCtl = new RadioCtl();
    public Form1()
    {
        InitializeComponent();
        RbCtl.RegisterRB(radioButton1);
        RbCtl.RegisterRB(radioButton2);
        RbCtl.RegisterRB(radioButton3);
        RbCtl.RegisterRB(radioButton4);
        RbCtl.RegisterRB(radioButton5);
    }
