    public override int SaveChanges()
    {
        foreach (Contact contact in Contacts.Local.Where(c => c.PersonId == null))
        {
            Contacts.Remove(contact);
        }
        return base.SaveChanges();
    }
