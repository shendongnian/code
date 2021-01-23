    public class UniversalConverter : IValueConverter
    {
        [ContentProperty]
        public ConverterItem[] Items { get; set; }
        public object DefaultValue { get; set; }
        //all other stuff goes here
    }
