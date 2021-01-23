    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        int noofcontrols = Convert.ToInt32(txtNumbers.Text);
        for (int i = 1; i <= noofcontrols; i++)
        {
            TextBox NewTextBox = new TextBox();
            NewTextBox.ID = "TextBox" + i.ToString();
            NewTextBox.Style["Clear"] = "Both";
            NewTextBox.Style["Float"] = "Left";
            NewTextBox.Style["Top"] = "25px";
            NewTextBox.Style["Left"] = "100px";
            //form1 is a form in my .aspx file with runat=server attribute
            form1.Controls.Add(NewTextBox);
        }
    }
