    var result = orders.Join(employees, 
                             od => od.EmployeeID,
                             em => em.EmployeeID,
                             (od, em) => new { od, em })
                       .Join(customers,
                             od => od.CustomerID,
                             ct => ct.CustomerID,
                             (od, ct) => new MyJoin
                                         {
                                             OrderID = od.OrderID,
                                             OrderDate = od.OrderDate,
                                             ShipCountry = od.ShipCountry,
                                             CompanyName = ct.CompanyName,
                                             ContactName = ct.ContactName,
                                             EmployeeName = (em.FirstName + ' ' + em.LastName),
                                         });
