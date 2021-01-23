    public class ProductBusinessLogic
    {
        private YourDbContext Context;
        public ProductBusinessLogic()
        {
            Context = new YourDbContext();
        }
    
        public IQeryable<Product> GetProducts(ProductSearchModel searchModel)
        {
            var result = Context.Products.AsQueryable();
            if (searchModel != null)
            {
                if (searchModel.Id.HasValue)
                    result = result.Where(x => x.Id == searchModel.Id);
                if (!string.IsNullOrEmpty(searchModel.Name))
                    result = result.Where(x => x.Name.Contains(searchModel.Name));
                if (searchModel.PriceFrom.HasValue)
                    result = result.Where(x => x.Price >= searchModel.PriceFrom);
                if (searchModel.PriceTo.HasValue)
                    result = result.Where(x => x.Price <= searchModel.PriceTo);
            }
            return result;     
        }
    }
