    List<TestObj> obj = new List<TestObj>()
    {
         new TestObj() { Id = 1, Tab = "tab1", Name = "name1" },
         new TestObj() { Id = 2, Tab = "tab1", Name = "name2" },
         new TestObj() { Id = 3, Tab = "tab1", Name = "name3" },
         new TestObj() { Id = 4, Tab = "tab2", Name = "name4" },
         new TestObj() { Id = 5, Tab = "tab2", Name = "name5" },
         new TestObj() { Id = 6, Tab = "tab4", Name = "name6" },
         new TestObj() { Id = 7, Tab = "tab3", Name = "name7" },
         new TestObj() { Id = 8, Tab = "tab3", Name = "name8" },
         new TestObj() { Id = 9, Tab = "tab3", Name = "name9" },
     };
     var list = obj.GroupBy(x => x.Tab).Select(x => new { key = x.Key, items = x }).ToList();
