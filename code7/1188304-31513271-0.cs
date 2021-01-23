    var order = context.Pages.AsQueryable().Where(o => o.Name == pName);
    if(order!=null)
     {
       order.ToList().ForEach(o=>context.Pages.Remove(o));
       context.SaveChanges();
     }
   
