    List<items> itemToInsertToDB = //fetchItems;
    foreach(items i in itemToInsertToDB)
    {
        TestType t = new TestType() { ColumnA = i.ColumnA, ColumnB = i.ColumnB };
        context.TestTypes.Add(t);
    }
    context.SaveChanges();
