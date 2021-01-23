    protected void finished_SelectedIndexChanged(object sender, EventArgs e)
    {
       DropDownList ddl = (DropDownList)sender;
       if (ddl.SelectedItem.ToString().Equals("Yes"))
       {
          theanswerValidator.Enabled = true;
       }
       else  // If someone selects yes and then regret it and selects no then disable validator again
       {
          theanswerValidator.Enabled = false;
       }
    }
		
