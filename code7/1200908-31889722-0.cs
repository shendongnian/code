             // db = DataContext
             var toInsert = from t1 in db.Table1
               where ...
               select new Table2
               {
                   name = b.name,
                   family = b.family
               };
            db.Table2.InsertAllOnSubmit(toInsert);
            db.SubmitChanges();
