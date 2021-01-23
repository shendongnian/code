    protected void Add_Button_Click(object sender, EventArgs e)
    {
        if (Add_Button.Text != "Cancel")
        {
            GridView1.FooterRow.Visible = true;
            Add_Button.Text = "Cancel";
            Panel2.Visible = false;
        }
        else
        {
             GridView1.FooterRow.Visible = false;
             Add_Button.Text = "Add New Record";
             GridView1.Columns[10].Visible = false;
             GridView1.Columns[11].Visible = false;
             /*etc*/ 
        }
    }
