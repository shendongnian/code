            foreach (Order k in db.OrderItems)
            {
                int sum = 0;
                foreach (Product product in db.Products)
                {
                    Statistic temp = new Statistic();
                    if (product.Id == k.productId)
                    {
                        sum += k.quantity;
                    }
                    temp.quantity = sum;
                    temp.Name = k.Product.Name();
                    if (!list_statistic.Exists(x => string.Compare(x.Name, temp.Name, true) == 0))
                    {
                        list_statistic.Add(temp);
                    }
                }
            }
