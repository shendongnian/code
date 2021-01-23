    protected void Page_Load(object sender, EventArgs e)
    {
        if(!Page.IsPostBack)
        {
            var f1 = new FileData { ID = 1 };
            var f2 = new FileData { ID = 2 };
            GridView1.DataSource = new List<FileData> { f1, f2 };
            GridView1.DataBind();
        }
    }
    protected void bntFileUpload_Command(object sender, CommandEventArgs e)
    {
        if(e.CommandName == "Upload")
        {
            int id = Int32.Parse(e.CommandArgument.ToString());
            lblOutput.Text = String.Format("You clicked on ID - {0}", id);
        }
    }
