    public Form1()
        {
            InitializeComponent();
            tools.Items.Add("Movies");
            tools.Items.Add("Music");
            tools.Items.Add("Documents");
            tools.Items.Add("Apps");
        }
        private void button1_Click(object sender, EventArgs e)
        {
            switch(tools.SelectedValue)
            {
                "Movies":
                          Response.Redirect("google.com");
                           break;
                "Music":
                          Response.Redirect("google.com");
                           break;
                "Documents":
                          Response.Redirect("google.com");
                           break;
                "Apps":
                          Response.Redirect("google.com");
                           break;
                   
             }
        }
