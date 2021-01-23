    public class Formatter
    {
        public static readonly DependencyProperty FormattedTextProperty = DependencyProperty.RegisterAttached(
            "FormattedText",
            typeof(string),
            typeof(Formatter),
            new PropertyMetadata(string.Empty, FrameworkPropertyMetadataOptions.AffectsMeasure, FormattedTextPropertyChanged));
        public static void SetFormattedText(DependencyObject textBlock, string value)
        {
            textBlock.SetValue(FormattedTextProperty, value);
        }
        public static string GetFormattedText(DependencyObject textBlock)
        {
            return (string)textBlock.GetValue(FormattedTextProperty);
        }
        private static void FormattedTextPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var textBlock = d as TextBlock;
            if (textBlock == null) return;
            const string @namespace = "http://schemas.microsoft.com/winfx/2006/xaml/presentation";
            var formattedText = (string)e.NewValue ?? string.Empty;
            formattedText = $@"<Span xml:space=""preserve"" xmlns=""{@namespace}"">{formattedText}</Span>";
            textBlock.Inlines.Clear();
            using (var xmlReader = XmlReader.Create(new StringReader(formattedText)))
            {
                var result = (Span)XamlReader.Load(xmlReader);
                textBlock.Inlines.Add(result);
            }
        }
    }
