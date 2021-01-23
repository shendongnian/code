    private void FillComboGroup()
    {
        try
        {
            if (cboSede.SelectedIndex > 0)
            {
               //the code here just retrieves an object
    
                // YOU'LL PROBABLY WANT TO ENABLE THE SECOND COMBO AGAIN HERE
            }
            else
            {
                cboEmpleado.Enabled = false;
                cboEmpleado.BackColor = Color.White;
            }
        }
        catch (Exception ex)
        {
            //here are some methods to save the exception in the log
        }
    }
