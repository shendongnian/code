    private void radComboBox1_SelectedIndexChanged(object sender,Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
    {
    if (radComboBox1.SelectedIndex==0)
    {
            //Alert Message       
    }
    else
    {
       radGridView1.AllowAddNewRow = true;
       //or Visible The Button
    }
    }
