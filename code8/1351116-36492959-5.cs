     using (var context = new YourContext())
    {
       var order= new Order{
         Name="",
         ManufacturerID= 2 ,         
         Employees = context.Employees.Where(e=> e.Name=="Name")    
      }
      context.Orders.Add(order);
      context.SaveChanges();
    }
