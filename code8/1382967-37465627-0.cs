    if (this.IsPostBack)
    {
        this.Validate();
        if (!this.IsValid)
        {
            string msg = "";
            // Loop through all validation controls to see which
            // generated the errors.
            foreach (IValidator aValidator in this.Validators)
            {
                if (!aValidator.IsValid)
                {
                    msg += "<br />" + aValidator.ErrorMessage;
                }
            }
            Label1.Text = msg;
        }
    }
