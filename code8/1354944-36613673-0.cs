      protected void Page_Load(object sender, EventArgs e)
        {
           
            if (!IsPostBack)
            {
                List<User> listUser = new List<User>();
                listUser.Add(new User() { Name = "U1" });
                listUser.Add(new User() { Name = "U2" });
                listUser.Add(new User() { Name = "U3" });
                ViewState["listUser"] = listUser;
            }
        }
        protected void Button_Click(object sender, EventArgs e)
        {
            var list = ViewState["listUser"]; //you can get the List from the ViewState
        }
