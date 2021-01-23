    protected void Page_Load(object sender, EventArgs e)
    {
        for (int i = 0; i < CheckBoxList.Items.Count; i++)
        {
            if(someCondition)
                CheckBoxList.Items[i].Selected = true;
        }
    }
