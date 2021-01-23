    static List<Category> FilterList(List<Category> list, List<Product> ProductList)
    {   
       var options = new ParallelOptions { MaxDegreeOfParallelism =  Environment.ProcessorCount * 10 };
       Parallel.For(0, list.Count, options, i => { list[i].ProductList = 
          ProductList.AsParallel().Where(p => p.CategoryID == list[i].CategoryID).ToList(); });    
       return list;
    }
