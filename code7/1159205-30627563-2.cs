    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {
            if (Add_Button.Text != "Cancel")
            {
                GridView1.FooterRow.Visible = false;
                GridView1.Columns[10].Visible = false;
                GridView1.Columns[11].Visible = false;
                GridView1.Columns[12].Visible = false;
                GridView1.Columns[13].Visible = false;
                GridView1.Columns[14].Visible = false;
                GridView1.Columns[15].Visible = false;
                GridView1.Columns[16].Visible = false;
            }
            else
            {
                GridView1.FooterRow.Visible = true;
            }
        }
    }
