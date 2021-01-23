        public interface IProductFilter
        {
            FilteredProducts GetProducts(); 
        }
        public class GetProductsByDate : IProductFilter
        {
            private DateTime _startDate;
            private DateTime _endDate;
            public GetProductsByDate(DateTime startDate, DateTime EndDate)
            {
                _startDate = startDate;
                _endDate = EndDate;
            }
            public FilteredProducts GetProducts()
            {
                // filter
            }
        }
