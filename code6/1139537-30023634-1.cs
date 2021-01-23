      public Info(string userName)
        {
            InitializeComponent();
    
            this.AInfoLv.Items.Add(new { Label = "Login" });
            this.AInfoLv.Items.Add(new { Label = " Username" });
            // userName variable contains value of input
        }
