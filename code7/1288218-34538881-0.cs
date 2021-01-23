    using System;
    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Controls;
    
    namespace App1
    {
        public sealed partial class MainPage
        {
            public MainPage()
            {
                InitializeComponent();
                Loaded += MainPage_Loaded;
            }
    
            private async void MainPage_Loaded(object sender, RoutedEventArgs e)
            {
                var dialog1 = new ContentDialog1();
                var result = await dialog1.ShowAsync();
                if (result == ContentDialogResult.Primary)
                {
                    var text = dialog1.Text;
                }
            }
        }
    }
