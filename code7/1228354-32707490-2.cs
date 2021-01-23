    public IEnumerable<Contacts> Edit(int id)
        {
            var GetContacts = from c in db.Contacts where c.ContactID == id
                            select c;
    
            return GetContacts.ToList();
    
        }
