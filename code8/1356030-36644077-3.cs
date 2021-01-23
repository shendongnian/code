    List<T_shirt_Company_v3.ViewModels.MyOrdersViewModel> list = (from o in new TshirtStoreDB().Orders
                        .Where(o => o.Username == currentUserId)
                        .OrderBy(o => o.OrderDate)
                        .Select(o => new MyOrdersViewModel()
                        {
                            OrderId = o.OrderId,
                            Address = o.Address,
                            FirstName = o.FirstName,
                            LastName = o.LastName,
                            City = o.City,
                            OrderDate = o.OrderDate,
                            PostalCode = o.PostalCode,
                            Total = o.Total,
                            HasBeenShipped = o.HasBeenShipped,
                            Details = (from d in o.OrderDetails
                                       select new MyOrderDetails
                                       {
                                           Description = d.Product.Description,
                                           Quantity = d.Quantity,
                                           Title = d.Product.Title,
                                           UnitPrice = d.UnitPrice
                                       }).ToList()
                        }).ToList() select o).ToList();
