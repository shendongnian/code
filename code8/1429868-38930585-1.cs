    var result=ctx.Order.Where(a=>a.Field1.Equals(id))
        .Join(ctx.OrderDetails.Where(b=>b.Field1.Contains("TEST")),
         x=>x.OrderId ,y=>y.OrderId ,(x,y)=>x)
    .AsEnumerable()
    .Select(x=>new CDOrder
        {
         OrderId = x.OrderId,
         Field1 = x.Field1,
         Field2=x.Field2, 
         OrderDate = x.OrderDate.ToString("MM/dd/yyyy")
        }).ToList();
