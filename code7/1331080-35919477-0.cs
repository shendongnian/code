    /// Your MVC-generated class. Add methods, getters, setters, whatever.
    /// FileHelpers doesn't use this class.
    class Merchant
    {
      public long Id { get; set; }
      public string Name { get; set; }
      public Nullable<int> Category { get; set; }
      public virtual MerchantCategory MerchantCategory { get; set; }
    }
    /// This is the class FileHelpers will use
    /// This class describes the CSV file only. Stick to whatever
    /// syntax conventions are required by FileHelpers.
    [DelimitedRecord(";")]
    class ProductMerchantFileSpec
    {
        [FieldQuoted(QuoteMode.OptionalForRead)]
        public long Id;
        [FieldQuoted(QuoteMode.OptionalForRead)]
        public string Name;
        [FieldQuoted(QuoteMode.OptionalForRead)]
        // Handle non-US formats such as , decimal points
        // convert from inches to centimetres? 
        // you get the idea...
        [FieldConverter(MyCustomizedCategoryConverter)] // you get the idea
        public int Category;
    }
    class Program
    {
        static void Main(string[] args)
        {
            var engine = new FileHelperEngine<ProductMerchantFileSpec>();
            var productMerchantRecords = engine.ReadFile(filePath);
            var productMerchants = productMerchantRecords
                .Select(x => new Merchant() { Id = x.Id, Name = x.Name, Category = x.Category });
        }
    }
