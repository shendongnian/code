        static List<Category> FilterList(List<Category> list, List<Product> ProductList)
        {
            var options = new ParallelOptions { MaxDegreeOfParallelism = Environment.ProcessorCount * 10 };
            Parallel.For(0, list.Count, options, i =>
            {                
                list[i].ProductList = new List<Product>();
                Parallel.For(0, ProductList.Count, options, i2 => {
                 if(ProductList[i2].CategoryID == list[i].CategoryID) 
                    list[i].ProductList.Add(ProductList[i2]); });                                
            });
            return list;
        }
