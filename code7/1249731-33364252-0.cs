    var query =
    	from contact in context.Contacts
    	where contact.IdNumber != null
    	&& !contact.IdNumber.Trim().Equals("")
    	&& contact.EDITED.Equals(0)
    	&& contact.NOTACTIVE.Equals(false)
    	&& contact.ID > 10001
    	&& context.Clients.Any(client =>
    		client.ContactID == contact.ID && client.EDITED == contact.EDITED && client.DELETED == contact.EDITED
    		&& context.Members.Any(member =>
    			member.ClientID == client.ID && member.EDITED == client.EDITED && member.DELETED == client.DELETED
    		)
    	)
    	group contact
    	by new ContactDetailsViewModelPart
    	{
    		IDNumber = contact.IdNumber,
    		LastName = contact.LastName
    	}
    	into idNumberGroup
    	where idNumberGroup.Count() > 1
    	select idNumberGroup.Key;
    return query.ToList();
