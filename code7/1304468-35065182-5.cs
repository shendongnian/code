    // You exclude the 'Extension' suffix when using in Xaml markup
    [ContentProperty("Text")]
    public class ColourExtension : IMarkupExtension
    {
        public string Text { get; set; }
        public object ProvideValue(IServiceProvider serviceProvider)
        {
            if (Text == null)
                throw new Exception("No Colour Key Provided");
            return StylingLookup.GetColour(Text);
        }
    }
