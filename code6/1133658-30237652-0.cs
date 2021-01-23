    [ContentProperty("Items")]
    public class UniversalConverter : IValueConverter
    {
        public UniversalConverter()
        {
            Items = new List<ConverterItem>();
        }
        public List<ConverterItem> Items { get; private set; } 
        //All other logic is the same
    }
