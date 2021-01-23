    public void ContactType(Contact contact)
      {
        var entry = _context.Entry(contact);
        entry.State = EntityState.Modified;
        //Set auditable/ unmoved properties we CAN control to not modified :)
        entry.Property(m => m.CreatedBy).IsModified = false;
        entry.Property(m => m.Created).IsModified = false;
        entry.Property(m => m.IsDeleted).IsModified = false;
        //type == New ContactType(){Id = 1}. All other properties are unset.
        contact.ContactTypes.Each(type => _context.Entry(type).State = EntityState.Unchanged);
        _context.SaveChanges();
      }
