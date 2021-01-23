    private void emailTxt_Validating(object sender, CancelEventArgs e)
        {
                  
        if (string.IsNullOrWhiteSpace(emailTxt.Text))
        {
            e.Cancel = true;
            errorEmail.SetError(emailTxt, "Email is Empty!");
            CancelBtn.Enabled = true;
        }
        else
        {
            string email = emailTxt.Text;
            Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            Match match = regex.Match(email);
            if (match.Success)
            {
                e.Cancel = false;
            }
            else
            {
                e.Cancel = true;
                errorEmail.SetError(emailTxt, "Incorrect Format Try... email@email.com");
                CancelBtn.Enabled = true;
                return;
            }                                
        }
    }
