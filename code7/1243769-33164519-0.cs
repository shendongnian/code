    var result = from r in book.Worksheet("Orders")
                 select new MyJoin
                 {
                     OrderID = r["OrderID"].Cast<int>(),
                     OrderDate = r["OrderDate"].Cast<DateTime>(),
                     ShipCountry = r["ShipCountry"].Cast<string>(),
                     CompanyName = r["CustomerID"].Cast<string>(),
                     ContactName = r["CustomerID"].Cast<string>(),
                     EmployeeName = r["EmployeeID"].Cast<string>()
                 };
