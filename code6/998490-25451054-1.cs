    using System.Collections.Generic;
    using System.Linq;
    using Windows.UI.Xaml.Controls;
    
    namespace App51
    {
        public sealed partial class MainPage : Page
        {
            public MainPage()
            {
                this.InitializeComponent();
                var kvps = new List<KeyValuePair<string, string>>();
                kvps.Add(new KeyValuePair<string, string>("ar", "Argentina"));
                kvps.Add(new KeyValuePair<string, string>("au", "Australia"));
                kvps.Add(new KeyValuePair<string, string>("be-fr", "Belgique"));
                this.lv.ItemsSource = kvps.Select(kvp => kvp.Value).ToList();
            }
        }
    }
