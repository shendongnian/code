    var results5 = (from acc in context.AccountSet
                            join contact in context.ContactSet
                                on acc.PrimaryContactId.Id equals contact.Id
                            select new
                            {
                                _contactId = contact.Id,
                                _accountId = acc.Id
                            }
                                ).ToList();
