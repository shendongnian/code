    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        string s = DropDownList1.SelectedItem.Value;
        if (s == "3")
        {
            CheckBox1.Attributes.Add("Style", "display:block");
        }
        else
        {
            CheckBox1.Style.Add("Style", "display:none");
        }
    }
