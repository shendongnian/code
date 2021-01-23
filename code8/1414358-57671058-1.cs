    using CsvHelper.Configuration;
    using CsvHelper.Configuration.Attributes;
    namespace DataImport
    {
    public class Products
    {
        [Index(0)]
        public string prop1
        {
            get;
            set;
        }
        [Index(1)]
        public decimal prop2
        {
            get;
            set;
        }
        [Index(2)]
        public int prop3
        {
            get;
            set;
        }
    public class ProductsMap : ClassMap<Products>
    {
        public ProductsMap()
        {
            Map(m => m.prop1);
            Map(m => m.prop2);
            Map(m => m.prop3);
        }
    }
