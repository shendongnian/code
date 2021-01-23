    class MyConverter : MarkupExtension
    {
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return new SolidColorBrush(Colors.Red);
        }
    }
