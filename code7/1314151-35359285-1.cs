    /// A 'real' class. Add methods, getters, setters, whatever.
    /// FileHelpers doesn't use this class.
    class Box
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public int Length { get; set; }
        public Box(int width, int height, int length)
        {
            this.Width = width;
            this.Height = height;
            this.Length = length;
        }
    }
    /// A 'real' class. Add methods, getters, setters, whatever.
    /// FileHelpers doesn't use this class.
    class ProductBox : Box
    {
        public ProductBox(int width, int height, int length) 
            : base(width, height, length)
        { }
        public int Name { get; set; }
    }
    /// This is the class FileHelpers will use
    /// This class describes the CSV file only. Stick to whatever
    /// syntax conventions are required by FileHelpers.
    [DelimitedRecord(";")]
    class ProductBoxFileSpec
    {
        [FieldQuoted(QuoteMode.OptionalForRead)]
        public int Width;
        [FieldQuoted(QuoteMode.OptionalForRead)]
        public int Height;
        [FieldQuoted(QuoteMode.OptionalForRead)]
        // Handle non-US formats such as , decimal points
        // convert from inches to centimetres? 
        // you get the idea...
        [FieldConverter(MyCustomizedLengthConverter)] 
        public int Length;
        [FieldOptional]
        public string SomeDummyExtraCSVColumn;
    }
    class Program
    {
        static void Main(string[] args)
        {
            var engine = new FileHelperEngine<ProductBoxFileSpec>();
            var productBoxRecords = engine.ReadFile(filePath);
            var productBoxes = productBoxRecords
                .Select(x => new ProductBox(x.Width, x.Height, x.Length) { Name = x.Name });
        }
    }
