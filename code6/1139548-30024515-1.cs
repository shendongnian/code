    public Info()
    {
        InitializeComponent();
        this.AInfoLv.Items.Add(new { Label = "Login" });
        this.AInfoLv.Items.Add(new { Label = " Username" });
        // use it here
        var userName = Login.userName;
    }
