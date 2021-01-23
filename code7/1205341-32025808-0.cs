        protected void Page_Load(object sender, EventArgs e)
        {
            Rep1.DataSource = new string[] { "Test" };
            Rep1.DataBind();
        }
        protected void Rep1_ItemCreated(object sender, RepeaterItemEventArgs e)
        {
            Repeater Rep2 = e.Item.FindControl("Rep2") as Repeater;
            Rep2.ItemCreated += Rep2_ItemCreated;
            Rep2.DataSource = new string[] { "Test" };
            Rep2.DataBind();
        }
        protected void Rep2_ItemCreated(object sender, RepeaterItemEventArgs e)
        {
            Repeater Rep3 = e.Item.FindControl("Rep3") as Repeater;
            Rep3.DataSource = new string[] { "Test" };
            Rep3.DataBind();
        }
        protected void LinkButtonSave_OnCommand(object sender, CommandEventArgs e)
        {
            LinkButton LinkButtonSave = (LinkButton)sender;
            // Here is the found repeater. The first parent returns the FooterTemplate
            Repeater Rep3 = LinkButtonSave.Parent.Parent as Repeater;
        }
