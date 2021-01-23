    var customerProds = prods.Select(i => {
                            var item = new { i.Product, i.Localization };
                            item.Product.Customer = i.Customer;
                            return item;
                        })
                        .ToList();
