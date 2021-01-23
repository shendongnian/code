        public ActionResult JoinSupToPro()
        {
            
            List<Supplier> dbS = new SupplierDBContext().Suppliers.ToList();
            List<Product> prod = db.Products.ToList();
            var innerJoinQuery = from pro in prod join sup in dbS on pro.SupplierId equals sup.ID
            select new {Name= pro.Name,Price =pro.Price, SupplierName =sup.Name , Phone =sup.Phone};
            IndexModel m = new IndexModel();
            m.MenuItems = new List<SupplierProduct>();
            foreach (var item in innerJoinQuery)
            {
                SupplierProduct p = new SupplierProduct();
                p.SupplierName = item.SupplierName;
                p.Phone = item.Phone;
                p.Price = item.Price;
                p.ProductName = item.Name;
                    m.MenuItems.Add(p);
            }
