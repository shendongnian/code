    private void radCheckBox1_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
    {
        if (args.ToggleState == Telerik.WinControls.Enumerations.ToggleState.On)
        {
            radGridView1.AllowAddNewRow = true;
        }
    
        else
        {
            radGridView1.AllowAddNewRow = false;
        }
    }
