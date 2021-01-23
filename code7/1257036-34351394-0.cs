    public static Contact UpdateContactName(ContactsRequest cr, Uri contactURL)
    {
      // First, retrieve the contact to update.
      Contact contact = cr.Retrieve<Contact>(contactURL);
      contact.Name.FullName = "New Name";
      contact.Name.GivenName = "New";
      contact.Name.FamilyName = "Name";
      try
      {
        Contact updatedContact = cr.Update(contact);
        Console.WriteLine("Updated: " + updatedEntry.Updated.ToString())
        return updatedContact;
      }
      catch (GDataVersionConflictException e)
      {
        // Etags mismatch: handle the exception.
      }
      return null;
    }
