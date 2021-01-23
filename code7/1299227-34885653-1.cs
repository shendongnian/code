    public partial class MainWindow : Window
    {
        int step = 0;
    
        public MainWindow()
        {
            InitializeComponent();
    
            var cultureInfo = CultureInfo.GetCultureInfo("et-EE");
            Thread.CurrentThread.CurrentUICulture = cultureInfo;
            SetLocalization(cultureInfo);
        }
    
        private void btnChange_Click(object sender, RoutedEventArgs e)
        {
            CultureInfo cultureInfo;
    
            switch (step)
            {
                case 0:
                    cultureInfo = CultureInfo.GetCultureInfo("fr-FR");
                    break;
                case 1:
                    cultureInfo = CultureInfo.GetCultureInfo("ru-RU");
                    break;
                case 2:
                    cultureInfo = CultureInfo.GetCultureInfo("en-US");
                    break;
                default:
                    cultureInfo = CultureInfo.GetCultureInfo("et-EE");
                    break;
            }
    
            Thread.CurrentThread.CurrentUICulture = cultureInfo;
            SetLocalization(cultureInfo);
            btnChange.Content = cultureInfo.EnglishName;
            step = ++step % 4;
        }
    
        private static void SetLocalization(CultureInfo cultureInfo)
        {
            var dict = new ResourceDictionary
            {
                Source = new Uri(string.Format("pack://application:,,,/Languages/{0}.xaml", cultureInfo.Name))
            };
    
            var existingDict = Application.Current.Resources.MergedDictionaries.FirstOrDefault(
                rd => rd.Source.OriginalString.StartsWith("pack://application:,,,/Languages/"));
    
            if (existingDict != null)
            {
                Application.Current.Resources.MergedDictionaries.Remove(existingDict);
            }
    
            Application.Current.Resources.MergedDictionaries.Add(dict);
        }
    }
