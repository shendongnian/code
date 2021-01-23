     StringBuilder ErrorBuilder = new StringBuilder();
     ErrorBuilder.Append("Following are errors :");
            if (txtFirstName.Text.Trim() == "")
            {
                txtFieldError = true;
                ErrorBuilder.AppendLine("Must enter first name");
                txtFirstName.BackColor = System.Drawing.Color.Yellow;
            }
            if (txtLastName.Text.Trim() == "")
            {
                txtFieldError = true;
                ErrorBuilder.AppendLine("Must enter Last name");
                txtLastName.BackColor = System.Drawing.Color.Yellow;
            }
            // Rest of conditions here 
            lblError.Text = ErrorBuilder.ToString(); 
