    private void radComboBox1_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
    {
        if (radComboBox1.SelectedItem != null)
        {
            radGridView1.AllowAddNewRow = true;
        }
        else
        {
            // alert
        }
    }
