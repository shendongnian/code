        System.Security.Principal.WindowsIdentity WI = System.Security.Principal.WindowsIdentity.GetCurrent();
        string sUserName = WI.Name;
        bool bAuthorized = false;
        string allowedGroup = "Admins";
        IdentityReferenceCollection irc = WI.Groups;
        foreach (IdentityReference ir in irc)
        {
            if(ir.Translate(typeof(NTAccount)).Value != allowedGroup)
            {
                bAuthorized = false;
            }
            else
            {
               bAuthorized = true;
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
