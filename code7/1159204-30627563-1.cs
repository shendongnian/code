    protected void Add_Button_Click(object sender, EventArgs e)
    {
        if (GridView1.FooterRow.Visible == false)
        {
            GridView1.Columns[8].Visible = true;
            GridView1.Columns[9].Visible = true;
            GridView1.Columns[10].Visible = true;
            GridView1.Columns[11].Visible = true;
            GridView1.Columns[12].Visible = true;
            GridView1.Columns[13].Visible = true;
            GridView1.Columns[14].Visible = true;
            GridView1.FooterRow.Visible = true;
            Add_Button.Text = "Cancel";
            Panel2.Visible = false;
        }
        else
        {
            // this block is executed because GridView1.FooterRow.Visible is true,
            // which was the result of Page_Load execution on the second click
            Add_Button.Text = "Add New Record"; 
            GridView1.FooterRow.Visible = false;
        }
    }
