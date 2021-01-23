    protected void Page_Load(object sender, EventArgs e)
        {
            rpt.DataSource = ListDescription();
            rpt.DataBind();
        }
       private object ListDescription()
        {
            return new string[] {"a","b","c" };
        }
