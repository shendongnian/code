    protected void Page_Load(object sender, EventArgs e)
    {
        for (int i = 0; i < CheckBoxList1.Items.Count; i++)
        {
            if(someCondition)
               CheckBoxList1.Items[i].Selected = true;
        }
    }
