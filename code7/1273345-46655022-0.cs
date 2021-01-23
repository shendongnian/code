    public class TextBlockFormatter
    {
        const string @namespace = "http://schemas.microsoft.com/winfx/2006/xaml/presentation";
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
            var textBlock = (TextBlock)d;
            if (textBlock.DataContext == null)
            {
                textBlock.DataContextChanged += TextBlock_DataContextChanged;
                return;
            }
            var query = (string)e.NewValue ?? string.Empty;
            HighlightSearch(textBlock, query);
        }
        private static void HighlightSearch(TextBlock textBlock, string value)
        {
            var name = ((Person)textBlock.DataContext).Name;
            var query = value.ToUpper();
            var indexOfSearch = name.ToUpper().IndexOf(query, 0);
            if (indexOfSearch < 0) return;
            // add normal text first
            var firstText = name.Substring(0, indexOfSearch).Replace("&", "&amp;");
            var first = $@"<Span xml:space=""preserve"" xmlns=""{@namespace}"">{firstText}</Span>";
            var firstResult = (Span)XamlReader.Load(first);
            // add the bold text
            var boldText = name.Substring(indexOfSearch, query.Length).Replace("&", "&amp;");
            var bold = $@"<Bold xml:space=""preserve"" xmlns=""{@namespace}"">{boldText}</Bold>";
            var boldResult = (Bold)XamlReader.Load(bold);
            // add the rest of the text
            var restStartIndex = indexOfSearch + query.Length;
            var restText = name.Substring(restStartIndex, name.Length - restStartIndex).Replace("&", "&amp;");
            var rest = $@"<Span xml:space=""preserve"" xmlns=""{@namespace}"">{restText}</Span>";
            var restResult = (Span)XamlReader.Load(rest);
            // Clear current textBlock
            textBlock.ClearValue(TextBlock.TextProperty);
            textBlock.Inlines.Clear();
            // Inject to inlines
            textBlock.Inlines.Add(firstResult);
            textBlock.Inlines.Add(boldResult);
            textBlock.Inlines.Add(restResult);
        }
        private static void TextBlock_DataContextChanged(FrameworkElement sender, DataContextChangedEventArgs args)
        {
            var block = (TextBlock)sender;
            if (block.DataContext == null) return;
            block.DataContextChanged -= TextBlock_DataContextChanged;
            var query = (string)sender.GetValue(FormattedTextProperty);
            HighlightSearch(block, query);
        }
    }
