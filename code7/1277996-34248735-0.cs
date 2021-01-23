    (from c in Filter<Comment>().OrderByDescending(m => m.Date)
    join p in Filter<Product>() on c.ProductId equals p.Id
    join u in Context.ShopUsers on c.CustomerId equals u.Id
    group c by c.ProductId into g
    select new {
      LatestComment=g.OrderByDescending(m => m.Date).FirstOrDefault(),
      Comments=g.Count()
    })
    .Select(c=>new CommentViewModel {
      Comment=c.LatestComment,
      Product=c.LatestComment.Product.Name,
      UserName=c.LatestComment.RealUserName,
      Name=c.LatestComment.Customer.FirstName+" "+c.LatestComment.Customer.LastName,
      Comments=c.Comments
    });
