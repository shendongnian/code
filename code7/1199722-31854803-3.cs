    Label lbl = new Label();
    protected void Button3_Click(object sender, EventArgs e)
    {        
        lbl.ID = "name";
        lbl.Text = Profession.SelectedItem.ToString();
        if(!Panel1.Controls.Contains(lbl)) //Check here if label already added
             Panel1.Controls.Add(lbl);
    }
