    using (var db = new Entities(myConnectionString)
    {
        db.BulkInsert(contactsToInsert);
    }
    
    // BulkSaveChanges is slower than BulkInsert but way faster then SaveChanges
    using (var db = new Entities(myConnectionString))
    {
    	db.Contacts.AddRange(contactsToInsert);
        db.BulkSaveChanges();
    }
