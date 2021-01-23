    public interface IProduct
    {
        string Name { get; }
        string ID { get; }
        string DescriptionShort { get; }
        string DescriptionLong { get; }
    }
    public partial class SearchedProductInternal : IProduct
    {
        private string _clsName;
        private string _interfaceName;
        private string _objectID;
        private string _shortDesc;
        private string _longDesc;
        public SearchedProductInternal(string _cName, string _iName)
        {
            _clsName = _cName;
            _interfaceName = _iName;
        }
        public string Name
        {
            get { return _clsName; }
        }
        string IProduct.Name
        {
            get { return _interfaceName; }
        }
        string IProduct.ID
        {
            get { return _objectID; }
        }
        string IProduct.DescriptionShort
        {
            get { return _shortDesc; }
        }
        string IProduct.DescriptionLong
        {
            get { return _longDesc; }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            SearchedProductInternal clsSearchProduct = new SearchedProductInternal("clsName", "interfaceName");
            Console.WriteLine(clsSearchProduct.Name);
            IProduct interfaceProduct = (IProduct)clsSearchProduct;
            Console.WriteLine(interfaceProduct.Name);
            Console.ReadLine();
        }
    }
