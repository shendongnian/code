     protected void ButtonUpdate_Click(object sender, EventArgs e)
    {
        foreach (RepeaterItem thisItem in RepeaterList.Items)
        {
            var chkBox = ((CheckBox)thisItem.FindControl("CheckboxValue"));
            if (chkBox.Checked)
            {
                string PKValue = chkBox.Attributes["value"];
                //Use this for DB update...
            }
        }
    }
     
   
