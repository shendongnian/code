    var lstcart = (from t in context.T_Order
                       join s in context.T_OrderDetails on t.ID equals s.Order_ID
                       join u in context.T_OrderDetailSpecification on s.ID equals u.OrderDetails_ID
                       join p in context.M_Product on s.Product_ID equals p.ID
                       join qrs in context.M_ProductCategory on p.ProductCategory_ID equals qrs.ID
                       where t.User_ID == u_id && s.OrderStatus_ID == 1 || s.OrderStatus_ID == 17
                       select new /// anonymous type
                       {
                           ID = s.ID,
                           Path = p.VirtualPath,
                           ProductCategory = qrs.Title,
                           Quantity = 1,
                           Title = p.Title,
                           Amount = u.Value,
                           Order_Id = s.Order_ID,
                           prod_Id = p.ID,
                           Preview = s.IsPreviewRequired
                       }).AsEnumerable()
                                .Select(result => new Cart /// create your object after query execution in memory
                                 {
                                    ID = result.ID,
                                    Path = result.VirtualPath,
                                    ProductCategory = result.Title,
                                    Quantity = result.Quantity,
                                    Title = p.Title,
                                    Amount = Convert.ToSingle(result.Amount),
                                    Order_Id = result.Order_ID,
                                    prod_Id = result.ID,
                                    Preview = result.IsPreviewRequired
                                }).ToList();
