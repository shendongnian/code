    public override int SaveChanges()
    {
        IEnumerable<ObjectStateEntry> changes = ((IObjectContextAdapter)this).ObjectContext.ObjectStateManager.GetObjectStateEntries( EntityState.Modified);  // will store a list of all modified items
        foreach(var change in changes)
        {
          string tableName = change.Entity.GetType().Name;     
          Type myType = Type.GetType(change.Entity.GetType().FullName); 
          string itemID = change.CurrentValues.GetValue(0);
          string request = "select * from dbo."+tableName+" where ID="+ itemID;
          object myObj_4 = db.Database.SqlQuery(myType, request, new SqlParameter("p0", tempID)).Cast<object>().ToList().First();
          foreach (PropertyInfo propertyInfo in myType.GetProperties().Where(g=>!g.GetGetMethod().IsVirtual))
          {
                var oldValue = propertyInfo.GetValue(myObj_4) ?? "";
                var newValue = propertyInfo.GetValue(changes.First().Entity) ?? "";
                if (oldValue.ToString() != newValue.ToString())
                {
                    //Log the diferences between object
                }
          }
        }
    }
