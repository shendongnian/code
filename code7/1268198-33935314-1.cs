    GridView grvPayrollDetails = null;
    
    foreach (GridViewRow row in grvPayroll.Rows)
    {
        if (row.HasControls())
        {
            foreach (Control ctrl in row.Controls)
            {
                if (ctrl.ID == "grvPayrollDetails" && grvPayrollDetails != null)
                {
                    grvPayrollDetails = (GridView)ctrl;
                    break;
                }
            }
    
            if (grvPayrollDetails != null)
            {
                break;
            }
        }
    }
