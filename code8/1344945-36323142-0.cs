    String EmailAddresstoCheck = "info@domain.com";
    NameResolutionCollection ncCol = service.ResolveName(("SMTP:" + EmailAddresstoCheck), ResolveNameSearchLocation.DirectoryOnly, true);
    if (ncCol.Count == 1)
    {
        if (ncCol[0].Contact != null)
        {
            if (EmailAddresstoCheck.ToLower() == ncCol[0].Mailbox.Address)
            {
                Console.WriteLine("Primary SMTP Address of " + ncCol[0].Contact.DisplayName);
            }
            else                             
            {
                Console.WriteLine("Proxy Address of " + ncCol[0].Contact.DisplayName);
                Console.WriteLine("Primary SMTP Address : " + ncCol[0].Mailbox.Address);
            }                    
        }                
    }
