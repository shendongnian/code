    var contactLookups = contactsCtx.StatusTypes.ToList();
    Action<Contact> interceptor = contact => {
        contact.Status = contactLookups.FirstOrDefault(l => contact.StatusId == l.Id);
    };
    // note that we add InterceptWith(...) to entity set
    var someContacts = 
        from c in contactsCtx.Contacts.InterceptWith(interceptor) 
        where c.FullName.StartsWith("Jo")
        orderby c.FullName, c.CompanyName
        select c;
    Console.WriteLine("--- SOME CONTACTS ---");
    foreach ( var c in someContacts )
    {
        Console.WriteLine(
            "{0}: {1}, {2}, {3}={4}", 
            c.Id, c.FullName, c.CompanyName, c.StatusId, c.Status.Name);
    }
