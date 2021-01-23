    public bool addToBasket(HttpContextBase httpcontext, int productid, int quantity)
            {
                bool success = true;
    
                Basket basket = GetBasket(httpcontext);
    
                // Not sure if GetBasket always returns a value so checking for NULLs 
                if (basket != null && basket.BasketItems.Any())
                {
                    BasketItem item = basket.BasketItems.FirstOrDefault(i => i.ProductId == productid);
    
                    if (item == null)
                    {
                        item = new BasketItem()
                        {
                            BasketId = basket.BasketId,
                            ProductId = productid,
                            Quantity = quantity
                        };
                        basket.BasketItems.Add(item);
                    }
                    else
                    {
                        item.Quantity = item.Quantity + quantity;
                    }
    
                    baskets.Commit();
    
                    success = true;
                }
                else
                {
                    // Basket is null or BasketItems does not contain any items. 
                    // You could return an error message specifying that if needed.
                    success = false;
                }
    
                return success;
            }
