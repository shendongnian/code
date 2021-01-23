    public List<Contact> DurationLeft(/*DateTime _date*/)
     {
            Loader loader = new Loader();
            List<Contact> clientContacts = new List<Contact>();
             clientContacts =loader.LoadLicenses();
             var firstemailfield=clientContacts[0].Email;
    
    
             return clientContacts;
      }
