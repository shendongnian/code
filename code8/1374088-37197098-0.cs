    class MyConverter : MarkupExtension
    {
        public override object ProvideValue(IServiceProvider serviceProvider)
        {            
            return System.Media.Brushes.Red;
        }
    }
