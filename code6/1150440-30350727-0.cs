    var x = cc.Products
                        .Include("Category")
                        .Include("Supplier")
                        .Include("Manufacturer")
                        .Include("ProductPrices")
                        .Include("ProductPrices.Valuta")
                        .Include("ProductPrices.UnitOfMeasure")
                        .OrderBy(delegate (Product p) {
                              //some logic here
                              //order by the greatest price
                              // e.g:
                              return p.ProductPrices.Max(i => i.Price);
                        });
