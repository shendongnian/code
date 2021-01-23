    private void btnParse_Click(object sender, EventArgs e)
    {
        string email = Convert.ToString(txtEmail.Text);
        email = email.Trim();
        if (email.Contains("@"))
        {
            //email = email.Remove(0, 1); <--- Remove this
            int IndexDomain = email.IndexOf("@") + 1;
            string UserName = email.Substring(0 , IndexDomain - 1);
            string DomainName = email.Substring(IndexDomain);
            MessageBox.Show("User name:"  +  UserName.ToString() + "\n"
              + "Domain Name:" + DomainName.ToString(), "Parsed String");
        }
        else
        {
            //Tell users that the email is invalid.
            //For example: MessageBox.Show("Invalid Email");
        }
    }
