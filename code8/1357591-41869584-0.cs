    You can call SelectedIndexChanged event for the radio buttons like this:
    
    protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgse){
        for (int i = 0; i < RadioButtonList1.Items.Count; i++)
            {
                if (RadioButtonList1.Items[i].Selected == true)
                {
                    RadioButtonList2.Items[i].Selected = false;
                    RadioButtonList2.Items[i].Enabled = false;
                }
                if (RadioButtonList1.Items[i].Selected != true)
                {
                    RadioButtonList2.Items[i].Enabled = true;
                }
          
            }
    }
