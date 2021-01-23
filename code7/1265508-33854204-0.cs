    public IQueryable GetQuery()
    {
        var db = new ContactsDbContext();
        var query = db.Contacts.Select(contact => new
        {
            Id = contact.Id,
            FullName = contact.FirstName + " " + contact.LastName,
            CompanyName = contact.CompanyName,
            StatusId = contact.StatusId
        })
        .AsEnumerable()
        .Select(contact => new
        {
            Id = contact.Id,
            FullName = contact.FullName,
            CompanyName = contact.CompanyName,
            Status = _statusTypes.FirstOrDefault(l => contact.StatusId == l.Id).Label
        })
        .AsQueryable();
        return query;
    }
