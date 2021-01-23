    protected void Page_Load(object sender, EventArgs e)
    {
       Button btnAdd = new Button();
       btnAdd.ID = "btnAdd";
       btnAdd.Attributes.Add("class", "myLoginButton");
       btnAdd.Attributes.Add("style", "position:relative; left:10px");
       btnAdd.Text = "Add User";
       btnAdd.Click += new EventHandler(btnAdd_Click);
       placeHolderUsers.Controls.Add(btnAdd); 
    }
