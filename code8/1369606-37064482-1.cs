    protected void radyears_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (radyears.SelectedValue == "Other")
            {
                lblothererror.Text = "Enter age in Textbox";
            }
            else
            {
                lblothererror.Text = "";
            }
        }
        protected void txtother_TextChanged(object sender, EventArgs e)
        {
            if (radyears.SelectedValue == "Other")
            {
                double years = 100;
                if (String.IsNullOrEmpty(txtother.Text) || (Convert.ToInt32(txtother.Text) > years))
                {
                    lblothererror.Text = "Invalid";
                }
                else
                {
                    lblothererror.Text = "valid";
                }
            }
            else
            {
                lblothererror.Text = "";
            }
        }
       
      
