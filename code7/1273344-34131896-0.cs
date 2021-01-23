    public class TextBlockFormatter
    {
        public static readonly DependencyProperty FormattedTextProperty = DependencyProperty.RegisterAttached(
        "FormattedText",
        typeof(string),
        typeof(TextBlockFormatter),
        new PropertyMetadata(null, FormattedTextPropertyChanged));
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
            // Clear current textBlock
            TextBlock textBlock = d as TextBlock;
            textBlock.ClearValue(TextBlock.TextProperty);
            textBlock.Inlines.Clear();
            // Create new formatted text
            string formattedText = (string)e.NewValue ?? string.Empty;
            string @namespace = "http://schemas.microsoft.com/winfx/2006/xaml/presentation";
            formattedText = $@"<Span xml:space=""preserve"" xmlns=""{@namespace}"">{formattedText}</Span>";
            // Inject to inlines
            var result = (Span)XamlReader.Load(formattedText);
            textBlock.Inlines.Add(result);
        }
    }
