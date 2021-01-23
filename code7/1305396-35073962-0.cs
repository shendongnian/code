    var rosters = departments.SelectMany(
        x => x.Employees
          .Where(y => y.HireDate >= Convert.ToDateTime("1/15/2015"))
          .Select(y => new Roster{ DepartmentId = x.DepartmentId, DepartmentName = x.DepartmentName, FirstName = y.FirstName, LastName = y.LastName, Gender = y.Gender, HireDate = y.HireDate})
      ).ToList();
