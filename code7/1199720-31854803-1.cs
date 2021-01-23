    Label lbl = new Label();
    protected void Button3_Click(object sender, EventArgs e)
    {        
        lbl.ID = "name";
        lbl.Text = Profession.SelectedItem.ToString();
        Panel1.Controls.Add( lbl);
    }
