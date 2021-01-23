    protected void Button3_Click(object sender, EventArgs e)
    {
        Label lbl = new Label();//here on every click new label initialized
        lbl.ID = "name";
        lbl.Text = Profession.SelectedItem.ToString();
        Panel1.Controls.Add( lbl);
    }
