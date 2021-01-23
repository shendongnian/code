    public void DeleteCartItem(string customerId, string storeId, string productId)
        {
            //Authenticate service            
            Authenticate();
            int _customerId = Convert.ToInt32(customerId);
            int _storeId = Convert.ToInt32(storeId);
            int _productId = Convert.ToInt32(productId);
            var _cartid = (from c in context.carts
                where c.CustomerId == _customerId && c.StoreId == _storeId && c.ProductId ==_productId
                select c);
            context.carts.RemoveRange(_cartid );
            context.SaveChanges();
        }
