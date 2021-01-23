    protected void Add_Button_Click(object sender, EventArgs e)
    {
        bool visibility = false;
        string buttonText = string.empty;
        if (Add_Button.Text != "Cancel") //Add Record
        {
            visibility = true;
            buttonText = "Cancel";
            Panel2.Visible = false;
        }
        else //Cancel
        {
            visibility = false;
            buttonText = "Add New Record";
        }
        Add_Button.Text = buttonText;
        ridView1.FooterRow.Visible = visibility;
        GridView1.Columns[10].Visible = visibility;
        GridView1.Columns[11].Visible = visibility;
        /*etc*/ 
    }
