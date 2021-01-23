    public static Contact CreateContact(ContactsRequest cr)
    {
      Contact newEntry = new Contact();
      // Set the contact's name.
      newEntry.Name = new Name()
          {
            FullName = "Elizabeth Bennet",
            GivenName = "Elizabeth",
            FamilyName = "Bennet",
          };
      newEntry.Content = "Notes";
      // Set the contact's e-mail addresses.
      newEntry.Emails.Add(new EMail()
          {
            Primary = true,
            Rel = ContactsRelationships.IsHome,
            Address = "liz@gmail.com"
          });
      newEntry.Emails.Add(new EMail()
          {
            Rel = ContactsRelationships.IsWork,
            Address = "liz@example.com"
          });
      // Set the contact's phone numbers.
      newEntry.Phonenumbers.Add(new PhoneNumber()
          {
            Primary = true,
            Rel = ContactsRelationships.IsWork,
            Value = "(206)555-1212",
          });
      newEntry.Phonenumbers.Add(new PhoneNumber()
          {
            Rel = ContactsRelationships.IsHome,
            Value = "(206)555-1213",
          });
      // Set the contact's IM information.
      newEntry.IMs.Add(new IMAddress()
          {
            Primary = true,
            Rel = ContactsRelationships.IsHome,
            Protocol = ContactsProtocols.IsGoogleTalk,
          });
      // Set the contact's postal address.
      newEntry.PostalAddresses.Add(new StructuredPostalAddress()
          {
            Rel = ContactsRelationships.IsWork,
            Primary = true,
            Street = "1600 Amphitheatre Pkwy",
            City ="Mountain View",
            Region = "CA",
            Postcode = "94043",
            Country = "United States",
            FormattedAddress = "1600 Amphitheatre Pkwy Mountain View",
          });
      // Insert the contact.
      Uri feedUri = new Uri(ContactsQuery.CreateContactsUri("default"));
      Contact createdEntry = cr.Insert(feedUri, newEntry);
      Console.WriteLine("Contact's ID: " + createdEntry.Id)
      return createdEntry;
    }
