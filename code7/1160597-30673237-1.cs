    public void SetContactTypesToUnchanged(Contact contact)
      {
        contact.ContactTypes.Each(type => _context.Entry(type).State = EntityState.Unchanged);
        _context.SaveChanges();
      }
