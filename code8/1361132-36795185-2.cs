    var query = (from emp in ctx.Employers
                 join order in ctx.Orders on emp.EmployeeID equals order.EmployerID 
                 join orderDet in ctx.Order_Details on order.OrderID equals orderDet.OrderID 
                 group new { emp, order, orderDet } by new { emp.FirstName, emp.LastName, order.OrderID } into orderGroup
                 let a = new
                 {
                     orderGroup.Key.FirstName,
                     orderGroup.Key.LastName,
                     orderGroup.Key.OrderID,
                     sum1 = orderGroup.Sum(x => x.orderDet.Quantity * x.orderDet.UnitPrice),
                 }
                 group a by new { a.FirstName, a.LastName} into empGroup
                 let a2 = new
                 {
                     empGroup.Key.FirstName,
                     empGroup.Key.LastName,
                     sum = empGroup.Sum(x => x.sum1),
                     count = empGroup.Count()
                 }
                 orderby a2.count descending
                 select new
                 {
                     a2.FirstName,
                     a2.LastName,
                     amountOfOrders = a2.count,
                     AveragePricePerOrder = a2.sum / a2.count
                 }).Take(10);
