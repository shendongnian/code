    using System;
    using System.Windows;
    
    namespace WpfApplication3
    {
        public partial class MainWindow
        {
            public MainWindow()
            {
                InitializeComponent();
                Loaded += MainWindow_Loaded;
            }
    
            private void MainWindow_Loaded(object sender, RoutedEventArgs e)
            {
            }
    
            private void SetTheme(string theme)
            {
                var mergedDictionaries = Resources.MergedDictionaries;
                mergedDictionaries.Clear();
                var dictionary = new ResourceDictionary {Source = new Uri(theme)};
                mergedDictionaries.Add(dictionary);
            }
    
            private void ButtonRedTheme_Click(object sender, RoutedEventArgs e)
            {
                SetTheme(@"pack://application:,,,/Themes/StyleRed.xaml");
            }
    
            private void ButtonBlueTheme_Click(object sender, RoutedEventArgs e)
            {
                SetTheme(@"pack://application:,,,/Themes/StyleBlue.xaml");
            }
        }
    }
