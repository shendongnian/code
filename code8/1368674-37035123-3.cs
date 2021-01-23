    results = (from t1 in context.Table1
               join t2 in context.Table2.WhereIn(x => x.CreatedOn, d1, d2) on t1.Id equals t2.Id
               where (name.Contains(t2.Name))
               && t1.EventName.Equals("Concert")
               select new MyObject
               {
                   Id = t2.Id,
                   EventName = t1.EventName,
                   Status = t2.Status,
                   ProjectName = t2.Name
               });
