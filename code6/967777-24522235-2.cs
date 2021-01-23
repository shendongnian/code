        public static void RunInContext(Action<PricelistContext> contextCallBack)
        {
            PricelistContext dbContext = null;
            try
            {
                dbContext = new PricelistContext();
                contextCallBack(dbContext);
            }
            finally
            {
                dbContext.Dispose();
                dbContext = null;
            }
        }
    
        //Example Call
        PricelistContext.RunInContext(db => {
            var result = db.PrisListes.OrderBy(p => p.Speciale);
            //loop through your items
        });
