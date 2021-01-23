    protected void SubmitBtn_Click(object sender, EventArgs e)
    {
        foreach(ListItem li in CheckBoxList1.items)
        {
            if(li.Selected)
            {
                //insert to database, the value is in item.Value
            }
        }
    }
