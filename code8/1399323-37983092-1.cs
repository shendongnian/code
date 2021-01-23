    protected void rptr_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            Label lblPartNumber = (Label)e.Item.FindControl("lblGenuineOnly");
            CheckBox chkPart = (CheckBox)e.Item.FindControl("orderPartNumber");
            if (string.IsNullOrEmpty(lblPartNumber.Text.Trim())) {
                //Display GENUINE ONLY in any label like lblPartNumber.Text = "GENUINE ONLY"
                chkPart.Visible = false;
            }
            else
            {
                chkPart.Visible = true;                
            }
        }
