    protected void Page_Load(object sender, EventArgs e)
    {
            CreateButton();
    }
    protected void CreateButton()
    {
        Button btn = new Button();
        btn.ID = "newDynamicBtn";
        btn.Text = "Click Me";
        //btn.Attributes.Add("runat", "server");
        //btn.Attributes.Add("onClick", "newDynamicBtn_Click");
        //btn.OnClientClick = "return confirm('are you sure ?')";
        btn.Click += newDynamicBtn_Click;
        form1.Controls.Add(btn);
    }
    protected void newDynamicBtn_Click(object sender, EventArgs e)
    {
        Response.Write(@"<script>alert('Hello')</script>");
    }
