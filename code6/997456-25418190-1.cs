        db.Entry(newContact).State = EntityState.Modified;
                
        var p1 = db.Set<Person>().Include(p => p.ContactList).FirstOrDefault(p =>p.Id == 1);
        p1.Contacts.Remove(newContact);
        var p3 = db.Set<Person>().Include(p => p.ContactList).FirstOrDefault(p => p.Id == 3);
        p3.Contacts.Add(newContact);
        db.SaveChanges();
