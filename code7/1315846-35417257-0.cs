    Outlook.Items items = oldContacts.Items;
    for (int i = items.Count; i >= 1; i--)
    {
       Outlook.ContactItem contact = items[i] as Outlook.ContactItem; 
       if (contact != null)  //could be a distribution list
       {
          contact.Delete();
       } 
    }
