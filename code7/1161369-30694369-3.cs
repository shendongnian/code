    System.Security.Principal.WindowsIdentity WI =  System.Security.Principal.WindowsIdentity.GetCurrent();
            string sUserName = WI.Name;
            bool bAuthorized = true;
            IdentityReferenceCollection irc = WI.Groups;
            foreach (IdentityReference ir in irc)
            {
                if(ir.value != allowedGroup)
                {
                    bAuthorized = false;
                    break;
                }
            }
            if(string.IsNullOrEmpty(sUserName))
            {
                MessageBox.Show("Your Name in domain doesn't exist");
            }
            if(bAuthorized == false)
            {
                MessageBox.Show("You don't have permissions to log in");
            }
            else
            {
                MessageBox.Show("Hello");
            }
