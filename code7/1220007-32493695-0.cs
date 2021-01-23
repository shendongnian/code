    protected void chkCheck_CheckedChanged(object sender, EventArgs e)
    {
        // Variable
        int total = 0;
        int amt = 0;
        int donateAmt = 0;
        foreach (GridDataItem item in rg.Items)
        {
            // Find Control
            CheckBox chkCheck = item.FindControl("chkCheck") as CheckBox;
            Label lblAmount = item.FindControl("lblAmount") as Label;
            TextBox txtAmount = item.FindControl("txtAmount") as TextBox;
            // Reset Amount
            amt = 0;
            donateAmt = 0;
            // Check
            if (chkCheck != null && chkCheck.Checked)
            {
                // Check & Get Value
                if (lblAmount != null && txtAmount != null)
                {
                    // Check & Set
                    if (lblAmount.Text.Trim() != string.Empty) 
                        amt = Convert.ToInt32(lblAmount.Text.Trim());
                    // Check & Set
                    if (txtAmount.Text != string.Empty) 
                        donateAmt = Convert.ToInt32(txtAmount.Text.Trim());
                    // Check current Amount in stock and donate amt
                    if (donateAmt > amt)
                    {
                        donateAmt = amt;
                        txtAmount.Text = donateAmt + "";
                    }
                    // Reset to the text 
                    
                }
                total += donateAmt;         
            }
        }
        lblTotal.Text = total + "";
    }
