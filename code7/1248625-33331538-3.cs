    using System;
    using System.Collections.ObjectModel;
    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Controls;
    
    namespace App1
    {
        public sealed partial class MainPage : Page
        {
            ObservableCollection<String> items = new ObservableCollection<string>();
    
            public MainPage()
            {
                this.InitializeComponent();
    
                items.Add("First Item");
                items.Add("Second Item");
                items.Add("Third Item");
                items.Add("Fourth Item");
    
                ItemsView.ItemsSource = items;
            }
    
            private void Button_Click(object sender, RoutedEventArgs e)
            {
                items.RemoveAt(ItemsView.SelectedIndex);
            }
        }
    }
