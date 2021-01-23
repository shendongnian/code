        db.Entry(newContact).State = EntityState.Modified;
                
        var p1 = db.Set<Person>().Include(p => p.ContactList)
            .FirstOrDefault(p =>p.Id == 1);
        p1.ContactList.Remove(newContact);
        var p3 = db.Set<Person>().Include(p => p.ContactList)
            .FirstOrDefault(p => p.Id == 3);
        p3.ContactList.Add(newContact);
        db.SaveChanges();
