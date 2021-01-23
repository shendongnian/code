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
            GridView1.Columns[8].Visible = false;
            GridView1.Columns[9].Visible = false;
            GridView1.Columns[10].Visible = false;
            GridView1.Columns[11].Visible = false;
            GridView1.Columns[12].Visible = false;
            GridView1.Columns[13].Visible = false;
            GridView1.Columns[14].Visible = false;
            GridView1.FooterRow.Visible = false;
            Add_Button.Text = "Add New Record"; 
        }
    }
