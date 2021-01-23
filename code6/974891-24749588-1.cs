    public class ProductService
    {
        private IFilter _filter=null;
        public ProductService( IFilter Filter)
        {
            _filter = Filter;
        }
        public void FilterProducts(String Constraints)
        {
             _filter.FilterConstraints(Constraints);
        }
    }
