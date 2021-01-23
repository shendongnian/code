    private bool ValidateControls()
        {
            lblMessage.Text = "";
           
            if ((string.IsNullOrEmpty(txtEid.Text)) && (string.IsNullOrEmpty(txtAccountNo.Text)) && (string.IsNullOrEmpty(txtPlot.Text)) && ((string.IsNullOrEmpty(txtLongitude.Text)) &&
                (string.IsNullOrEmpty(txtYlatitude.Text))))
            {
    
     if ((!string.IsNullOrEmpty(drpBranch.SelectedValue)) && (string.IsNullOrEmpty(txtPlot.Text)))
            {
                lblMessage.Text = "Please enter Plot number to get the Network details";
                lblMessage.ForeColor = Color.Red;
                    return false;
            }
            if ((!string.IsNullOrEmpty(txtBlock.Text)) && (string.IsNullOrEmpty(txtPlot.Text)))
            {
                lblMessage.Text = "Please enter Plot number to get the Network details";
                lblMessage.ForeColor = Color.Red;
                    return false;
            }
    else
    {
    
    
                lblMessage.Text = "Please enter either EID or Account Number or Plot Number or X,Y co ordinates  to get the Network details";
                lblMessage.ForeColor = Color.Red;
                return false;
            }
    }
            return true;
        }
