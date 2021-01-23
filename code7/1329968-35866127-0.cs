    var res = (from sto in _context.Stores
               join pro in _context.Products
               on new { sto.Type1, transportId } equals
                  new { Type1 = pro.Type.ToString(), pro.transportId }
               into storeProducts
               from pro in storeProducts.DefaultIfEmpty()
               group pro by pro.Type into pt
               select new TypeTransportation()
               {
                   Type = pt.Key,
                   Count = pt.Count()
               }).ToList();
