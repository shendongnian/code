    var sales = from sale in db.SalePerProducts
                            join product in db.Products
                            on sale.ProductId equals product.ProductId
                            join invoice in db.Invoices
                            on sale.InvoiceId equals invoice.InvoiceId
                            where sale.ProductId == product.ProductId &&
                                    invoice.IssueDate.Date == date
                            group sale by new { sale.ProductId,product.Title } into g
                            select new
                            {
                                ProductId = g.Key.ProductId,
                                Product_Title = g.Key.Title,
                                Quantity_Sold = g.Sum(sale => sale.Quantity)
                            };
