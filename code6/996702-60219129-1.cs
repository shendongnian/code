    private CheckBox cb_All = null;
    private void CheckBox_Initialized(object sender, EventArgs e)
    {
       cb_All = (CheckBox)sender;
    }
    
    private void Function()
    {
       if(cb_All != null)
          cb_All.IsChecked = true; //or false 
    }
