    public static IEnumerable<SelectListItem> MyList(int? id, string name=null)
    {
      IQueryable<Entity> query = db.Entity;
      if (id != null)
        query = query.Where(p => p.Id == id);
      if (name != null)
        query = query.Where(p => p.Name == name);
      //else
      //  query = query.Where(p => p.Name != null);
      return query.Select(...).ToList();
    }
