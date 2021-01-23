    private void txtFirstname_Validating(object sender, CancelEventArgs e)
    {
        if (string.IsNullOrEmpty(this.txtFirstname.Text))
        {
            this.errorProvider1.SetError(this.txtFirstname, "Some Error");
            e.Cancel = true;
        }
        else
        {
            this.errorProvider1.SetError(this.txtFirstname, null);
        }
    }
    private void btnSave_Click(object sender, EventArgs e)
    {
        if (this.ValidateChildren())
        {
            //Here the form is in a valid state
            //Do what you need when the form id valid
        }
        else
        {
            //Show error summary
        }
    }
