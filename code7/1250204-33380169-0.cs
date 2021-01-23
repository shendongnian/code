     var contacts = from contact in db.Contacts
                       .Include(relation => relation.Relation
                            .Where(s => relation.ContactID == contact.ContactID)
                            .OrderByDescending(d => d.StartDate)
                            .FirstOrDefault())
                       select new ContactViewModel
                        {
                            ContactID = contact.ContactID,
                            Name = contact.Name,
                            Position = relation.Position,
                            Company = relation.Company.CompanyName
                        };
