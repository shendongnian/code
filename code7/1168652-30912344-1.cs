    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        string s = DropDownList1.SelectedItem.Value;
        if (s == "3")
        {
           CheckBox1.Attributes["style"] = "display:block;";
        }
        else
        {
           CheckBox1.Attributes["style"] = "display:none;";
        }
    }
