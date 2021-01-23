    protected void radyears_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (radyears.SelectedValue == "Other")
            {
                lblothererror.Text = "Enter value in Textbox please";
            }
            
        }
    
        protected void txtother_TextChanged(object sender, EventArgs e)
        {
            if (radyears.SelectedValue == "Other")
            {
                double years = 123;//Any Value
                if (String.IsNullOrEmpty(txtother.Text) || (!double.TryParse(txtother.Text, out years)))
                {
                    lblothererror.Text = "Not Valid Input";
                    return;
                }
                else
                {
                    lblothererror.Text = "valid number";
                    return;
                }
            }
            else
            {
                lblothererror.Text = "";
                return;
            }
        }
