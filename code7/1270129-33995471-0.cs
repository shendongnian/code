    protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
    {
        DropDownList2.Items.Clear();       //remove
        LoadOptions1();                    //remove
    
        string selected2 = DropDownList2.SelectedItem.Value;
        DropDownList2.Visible = true;      //remove
        //...
