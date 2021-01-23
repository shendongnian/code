    var x = (from t in Context.Testers.AsEnumerable()
             join u in Context.Users on t.TesterId equals u.TesterId into group1
             from a in group1.DefaultIfEmpty()
             join v in Context.ValidForms on a.DepartmentId equals v.DepartmentId into group2
             from b in group2.DefaultIfEmpty()
             select new MyEntity {
                 col1 = b.col1,
                 col2 = b.col2
             }).AsEnumerable();
