    using (var ctx = new TestContext())
    {
    	var first = ctx.Entity_Basics.First();
    	var objectStateEntry = ((IObjectContextAdapter)ctx).ObjectContext.ObjectStateManager.GetObjectStateEntry(first);
    
    
    	//ctx.Entity_Basics.Delete();
    	//ctx.Entity_Basics.Update(x => new Entity_Basic() { ColumnInt = 2 });
    }
