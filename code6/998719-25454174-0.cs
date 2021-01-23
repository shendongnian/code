    var q = (from p in northwind.Products
            where p.ProductID == ProductId
            select new ProductEditViewModel
            {
                ProductID = p.ProductID,
                ProductName = p.ProductName,
                UnitPrice = p.UnitPrice,
                Discontinued = p.Discontinued,
                SupplierItems = from sup in northwind.Suppliers
                                select new SelectListItem
                                    {
                                        Text = sup.CompanyName,
                                        Value = SqlFunctions.StringConvert((double)sup.SupplierID),
                                        Selected = sup.SupplierID == p.SupplierID
                                    },
                CategorySelectedId = p.CategoryID,
                CategorieItems = from cat in northwind.Categories select cat,
                QuantityPerUnitSelectedId = p.QuantityPerUnit,
                //remove this from here
                //QuantityPerUnitItems = QuantityPerUnit.QuantityPerUnitItems
            })
            .AsEnumerable()
            .Select(p => new ProductEditViewModel
            {
                p.ProductID,
                //all of the other properties 
                QuantityPerUnitItems = QuantityPerUnit.QuantityPerUnitItems,
            };
