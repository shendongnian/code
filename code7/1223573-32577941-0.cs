            string idTermEmail = "sip:" + txtTermFirstName.Text + "." + txtTermLastName.Text + "@domain.com";
            PSCommand command3 = new PSCommand();
            command3.AddCommand("Set-Mailbox");
            command3.AddParameter("Identity", username);
            var sipAddress = new Hashtable();            
            
            sipAddress.Add("remove", idTermEmail);
            command3.AddParameter("EmailAddresses", sipAddress);
            powershell.Commands = command3;
            powershell.Invoke();
