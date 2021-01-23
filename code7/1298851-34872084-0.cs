    var query = (from r in Col.AsQueryable<Result>()
                           .Where<Result>(x => x.Name == txtName.Text && x.Telephone.Count > 0)
                           .SortBy<Result>("Salary")
                           select new
                           {
                              Id = r._Id,
                              Name = r.Name,
                              Salary = r.Salary,
                              Telephone=r.Telephone
                           }
                 ).ToList();
