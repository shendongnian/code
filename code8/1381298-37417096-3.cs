    var List1 = new[]
                {
                    new { Name = "Prod1", Id = 1, Value = 0 },
                    new { Name = "Prod2", Id = 2, Value = 50 },
                    new { Name = "Prod3", Id = 3, Value = 0 },
                    new { Name = "NotInList2", Id = 4, Value = 0}
                };
    var List2 = new[]
                {
                    new { Name = "Prod1", Id = 1, Value = 25 },
                    new { Name = "Prod2", Id = 2, Value = 100 },
                    new { Name = "Prod3", Id = 3, Value = 75 }
                };
    var results = from l1 in List1
                  join l2temp in List2 on l1.Id equals l2temp.Id into grpj
                  from l2 in grpj.DefaultIfEmpty()
                  select new
                  {
                      l1.Id,
                      l1.Name,
                      Value = l1.Value == 0 && l2 != null ? l2.Value : l1.Value
                  };
    foreach(var item in results)
        Console.WriteLine(item);
