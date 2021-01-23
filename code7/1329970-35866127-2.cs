    var res = (from sto in _context.Stores
               join pro in _context.Products
               on new { sto.Type1, transportId } equals
                  new { Type1 = pro.Type.ToString(), pro.transportId }
               into storeProducts
               from pro in storeProducts.DefaultIfEmpty()
               group sto by sto.Type1 into pt
               select new 
               {
                   Type = pt.Key, // the string value, there is no way to convert it to int inside the SQL
                   Count = pt.Count()
               }).AsEnumerable() // switch to LINQ to Objects context
               .Select(pt => new TypeTransportation()
               {
                   Type = Convert.ToInt32(pt.Type), // do the conversion here
                   Count = pt.Count()
               }).ToList();
