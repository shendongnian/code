    using (var context = new TestContext())
    {
    	context.WorkItem.Add(new WorkItem()); //Construct valid entity
    	context.SaveChanges();
    }
