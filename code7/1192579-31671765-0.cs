    protected void ddlTaxCodes1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlAcCode.SelectedValue != null || ddlAcCode.SelectedValue != "")
            {
                ddlAcCode.Enabled = false;
    
                string selItem = ddlAcCode.SelectedItem.Text;
    
                if (selItem.Contains("0%"))
                {
                    txtAmount.Text = "0.00";
                    txtAmount.Enabled = false;
    
                    txtRemark.Text = "";
                }
                else
                {
                    txtAmount.Text = "";
                    txtRemark.Text = "";
                }
            }
        }
