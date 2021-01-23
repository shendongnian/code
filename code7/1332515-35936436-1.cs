    List<Cart> newLstCart = new List<Cart>();
            foreach (var old in lstcart)
            {
                newLstCart.Add(new Cart()
                {
                    ID = old.ID,
                    Path = old.Path,
                    ProductCategory = old.ProductCategory,
                    Quantity = old.Quantity,
                    Title = old.Title,
                    Amount = float.Parse(old.Amount),
                    Order_Id = old.Order_Id,
                    prod_Id = old.prod_Id,
                    Preview = old.Preview
                });
            }
