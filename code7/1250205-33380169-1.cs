    var contacts = from relation in db.Relations
        join contact in db.Contacts on relation.ContactID equals contact.ContactID
        join company in db.Companies on relation.CompanyID equals company.CompanyID
        orderby relation.StartDate descending
        select new ContactViewModel
        {
            ContactID = contact.ContactID,
            Name = contact.Name,
            Position = relation.Position,
            Company = company.CompanyName
        };
