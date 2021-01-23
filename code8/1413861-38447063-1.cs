        using (var _storeEntities = new StoreEntities())
            {
          _storeEntities .Configuration.LazyLoadingEnabled = false;
        
            var test = _storeEntities.Orders.Where(r => r.Id.ToString() == orderId)
                                            .Include(x => x.User).ToList();
            }
