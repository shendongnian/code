    public class SearchedProductInternal : IProduct
    {
        string _name = "test";
        public string Name
        {
            get
            {
                return _name;
            }
        }
    }
    public interface IProduct
    {
        string Name { get; }
    }
