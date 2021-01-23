    Func<IQueryable<ItemResponse>,IEnumerable<TestClass>> SelectResult = q => 
    q.GroupBy(ir => ir.ItemID)
     .Select(
         grouped => new TestClass
         {
             ItemID = grouped.Key,
             Average = (double)grouped.Average(g => g.OptionValue),
             ...
         });
