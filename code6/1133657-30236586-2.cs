    [ContentProperty("Items")]
    public class UniversalConverter : IValueConverter
    {
        public ConverterItem[] Items { get; set; }
        public object DefaultValue { get; set; }
        //all other stuff goes here
    }
