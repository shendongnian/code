    using (var db = new CassaContext())
    using (var transaction = db.Database.BeginTransaction())
    {
    	var DbSet = db.GetByName(item.Name);
    	DbSet.RemoveRange(DbSet);
    	db.SaveChanges();
    
    	for (var i = 0; i < data.Count; i++)
    	{
    		JObject jitem = data[i] as JObject;
    		var dbobj = vm.Db.JsonToObject(jitem);             
    		DbSet.Add(dbobj);
    	}
    	db.SaveChanges();
    
    	transaction.Commit();
    }
