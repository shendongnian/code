    GroupBox gBox = this.Controls.OfType<GroupBox>().FirstOrDefault(c => c.Enabled);
    
    List<string> values = new List<string>();
    if(gBox != null)
    {
        foreach(var txtBox in gBox.Controls.OfType<TextBox>())
        {
            values.Add(txtBox.Text);
        }
    }
