    var contacts = from contact in db.Contacts
                   let relation = contact.Relation
                                  .OrderByDescending(d => d.StartDate)
                                  .FirstOrDefault()
                   select new ContactViewModel
                   {
                       ContactID = contact.ContactID,
                       Name = contact.Name,
                       Position = relation.Position,
                       Company = relation.Company.CompanyName
                   };
