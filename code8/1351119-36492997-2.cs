        List<Employee> employees = _ctx.Employees.Where(e => id > 0 && id <= 5);
        
        foreach(Employee emp in employees)
        {
           Order theOrder = emp.Orders.FirstOrDefault(o => o.ID == order.ID);
           if(theOrder != null)
           {
               Console.WriteLine("Employee {0} has served order {1}", emp.ID, theOrder.ID);
           }
        }
