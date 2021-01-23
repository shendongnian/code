    protected void btnRenew_Click(object sender, ImageClickEventArgs e)
    {
        //other code removed for clarity on where and how this alert is triggered
         if (newExpiryDate.Date == memberDetails.ExpiryDate.Date)
         {
    ClientScript.RegisterClientScriptBlock
            ("".GetType(), "s", "<script>alert('Invalid renewal date');</script>");
         }
    }
    
