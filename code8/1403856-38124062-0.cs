    using (var db = new NotentoolEntities())
       {
          var GOB = db.tabGroupOfBranches.Where(x => x.intGroupID == ID).Select(y => new GroupOfBranches
              {
                  /// here specify your fields
              }).AsNoTracking().ToList();
        }
