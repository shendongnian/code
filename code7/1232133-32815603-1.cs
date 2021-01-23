    protected void Button1_Click(object sender, EventArgs e)
    {
        for (int i = 0; i <CheckBoxList1.Items.Count; i++)
        {
            if (CheckBoxList1.Items[i].Selected)
            {
                CheckBoxList1.Items[i].Attributes.Add("style", "color:red");
            } 
        }
    }
