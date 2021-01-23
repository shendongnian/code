    var amountByProducts = from p in _context.Products
                 join rp in _context.ReleasePlans 
                 on p.ProductId equals rp.ProductId
                 where rp.DepartmentDepartmentId == departmentId
                 group new
                 {
                     p.ProductName,
                     Quarter = (DbFunctions.AddDays(rp.DateTime,2).Month - 1) / 3 + 1,
                     rp.Amount
                 }
                 // group all product plans in a given quarter
                 by new
                 {
                     p.ProductName, // shouldn't this be ProductId?
                     Quarter = (DbFunctions.AddDays(rp.DateTime,2).Month - 1) / 3 + 1
                 }
                 into grp
                 // from the grouped entries, sum the amounts
                 select new ValuePairPlanned()
                 {
                    PlannedAmount = grp.Sum(g => g.Amount),
                    Quarter = grp.Key.Quarter,
                    ProductName = grp.Key.ProductName
                 };
    return amountByProducts.ToList();
