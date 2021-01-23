    public List<Top_100_Result> GetTopProductsByTypeName()
    {
        var products = CacheManager.GetFromCache<List<Top_100_Result>>("TOP_100_RESULT");
        
        //Add to cache if not existed
        if (products == null)
        {
                using (EmbraceEntities ctx = new EmbraceEntities())
                {
                    var productObjects = ctx.Top_100(null);
        
                    products = new List<Top_100_Result>(productObjects.Distinct());
        
                    CacheManager.AddToCache<List<Top_100_Result>>("TOP_100_RESULT", products);
                }
        }
        
       return products;
    }
