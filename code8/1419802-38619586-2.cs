    // Note: Not my code, but I can't find the original source
    public static class RichTextBoxService
    {
        public static string GetContent(DependencyObject obj)
        {
            return (string)obj.GetValue(ContentProperty);
        }
        public static void SetContent(DependencyObject obj, string value)
        {
            obj.SetValue(ContentProperty, value);
        }
        public static readonly DependencyProperty ContentProperty =
            DependencyProperty.RegisterAttached("Content",
            typeof(string), 
            typeof(RichTextBoxHelper),
            new FrameworkPropertyMetadata 
            {
                BindsTwoWayByDefault = true,
                PropertyChangedCallback = OnDocumentChanged,
            });
        private static void OnDocumentChanged(DependencyObject obj, DependencyPropertyChangedEventArgs e)
        {
            var richTextBox = (RichTextBox)obj;
            // Parse the XAML content to a document (or use XamlReader.Parse())
            var xaml = GetContent(richTextBox);
            var doc = new FlowDocument();
            var range = new TextRange(doc.ContentStart, doc.ContentEnd);
            
            range.Load(new MemoryStream(Encoding.UTF8.GetBytes(xaml)), DataFormats.Xaml);
            richTextBox.Document = doc;
            // When the document changes update the source
            range.Changed += (s, args) =>
            {
                if (richTextBox.Document == doc)
                {
                    MemoryStream buffer = new MemoryStream();
                    range.Save(buffer, DataFormats.Xaml);
                    SetContent(richTextBox, Encoding.UTF8.GetString(buffer.ToArray()));
                }
            };
        }
    }
