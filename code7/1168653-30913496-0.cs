    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            try
            {
                InitializeComponent();
            }
            catch (XamlParseException xamlEx)
            {
                throw new ThemeNotFoundException(newThemesUri, xamlEx);
            }
            catch (IOException ioEx)
            {
                throw new ThemeNotFoundException(newThemesUri, ioEx);
            }
        }
    }
