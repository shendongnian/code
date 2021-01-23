    list.GroupBy(i => i.UserName)
       .Select(i => new {
             UserName = i.Key,
             CategoryA = i.FirstOrDefault(x => x.Grade == "A").Percent,
             CategoryB = i.FirstOrDefault(x => x.Grade == "B").Percent,
             CategoryC = i.FirstOrDefault(x => x.Grade == "C").Percent,
             // ...
          });
