    var sales=db.Customers
        .GroupBy(c=>c.SomeColumn)
        .Select(g=>new
         {
            Count1=g.Count(someCondition),
            Count2=g.Count(otherCondition)
         })
        .Select(c=> new MyModel
         {
            count1=c.Count1,
            count2=c.Count2, 
            finalCount=c.Count1-c.Count2
         });
