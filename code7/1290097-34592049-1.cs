    public partial class MainWindow : Window
    {
        private const string _stateFile = "state.xaml";
        public MainWindow()
        {
            InitializeComponent();
            richTextBox.IsReadOnly = false;
        }
        private void createLinkButton_Click(object sender, RoutedEventArgs e)
        {
            richTextBox.IsDocumentEnabled = false;
            richTextBox.IsReadOnly = true;
            var textRange = richTextBox.Selection;
            var hyperlink = new Hyperlink(textRange.Start, textRange.End);
            hyperlink.TargetName = "value";
            hyperlink.NavigateUri = new Uri("http://search.msn.com");
            hyperlink.RequestNavigate += HyperlinkOnRequestNavigate;
            richTextBox.IsDocumentEnabled = true;
            richTextBox.IsReadOnly = false;
        }
        private void HyperlinkOnRequestNavigate(object sender,
            RequestNavigateEventArgs args)
        {
            // Outputs: "Requesting: http://search.msn.com, target=value" 
            Console.WriteLine("Requesting: {0}, target={1}", args.Uri, args.Target);
        }
        private void SaveXamlPackage(string filePath)
        {
            var range = new TextRange(richTextBox.Document.ContentStart,
                richTextBox.Document.ContentEnd);
            var fStream = new FileStream(filePath, FileMode.Create);
            range.Save(fStream, DataFormats.XamlPackage);
            fStream.Close();
        }
        void LoadXamlPackage(string filePath)
        {
            if (File.Exists(filePath))
            {
                var range = new TextRange(richTextBox.Document.ContentStart,
                    richTextBox.Document.ContentEnd);
                var fStream = new FileStream(filePath, FileMode.OpenOrCreate);
                range.Load(fStream, DataFormats.XamlPackage);
                fStream.Close();
            }
            // Reapply event handling to hyperlinks after loading, since these are not saved:
            foreach (var paragraph in richTextBox.Document.Blocks.OfType<Paragraph>())
            {
                foreach (var hyperlink in paragraph.Inlines.OfType<Hyperlink>())
                {
                    hyperlink.RequestNavigate += HyperlinkOnRequestNavigate;
                }
            }
        }
        private void saveButton_Click(object sender, RoutedEventArgs e)
        {
            SaveXamlPackage(_stateFile);
        }
        private void loadButton_Click(object sender, RoutedEventArgs e)
        {
            LoadXamlPackage(_stateFile);
        }
    }
