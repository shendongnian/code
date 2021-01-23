    from c in Filter<Comment>().OrderByDescending(m => m.Date)
    join p in Filter<Product>() on c.ProductId equals p.Id
    join u in Context.ShopUsers on c.CustomerId equals u.Id
    group c by c.ProductId into g
    let firstComment = g.OrderByDescending(m => m.Date).FirstOrDefault()
    select new CommentViewModel
            {
                Comment = firstComment,
                Product = firstComment != null ? firstComment.Product.Name, : "",
                UserName = firstComment != null ? firstComment.Customer.RealUserName : "",
                Name = firstComment != null ? firstComment.Customer.FirstName + " " +
                                              firstComment.Customer.LastName : "",
                Comments = g.Count()
            };
