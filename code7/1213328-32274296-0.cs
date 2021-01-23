         var getDep = from row in samples.store
            group row by row.Department
            into g
            select new
            {
               DepartmentName = g.Key,
               Employees =
                  from emp in g
                  group emp by emp.EmployeeID
                  into eg
                  select new
                  {
                     Employee = eg.Key,
                     EmployeeProducts = eg
                  }
            };
         foreach (var it in getDep)
         {
            Console.WriteLine(string.Format("Department: {0}", it.DepartmentName));
            foreach (var emp in it.Employees)
            {
               Console.WriteLine(string.Format("Employee: {0}", emp.Employee));
               var totalCount = 0;
               foreach (var product in emp.EmployeeProducts)
               {
                  Console.WriteLine(string.Format("Product: {0}  Count: {1}", product.Product, product.Count));
                  totalCount += product.Count;
               }
               Console.WriteLine("Total {0}", totalCount);
            }
         }
