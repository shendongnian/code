        static List<Category> FilterList(List<Category> list, List<Product> ProductList)
        {
            Parallel.For(0, list.Count, i =>
            {
                list[i].ProductList = new List<Product>();
                for (int i2 = 0; i2 < ProductList.Count; i2++)
                    if (ProductList[i2].CategoryID == list[i].CategoryID) list[i].ProductList.Add(ProductList[i2]);
            });            
            return list;
        }
