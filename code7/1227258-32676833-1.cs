    using System;
    using System.Collections.Generic;
    using System.Windows;
    using System.Windows.Controls;
    
    namespace WpfListBox._32674841
    {
        /// <summary>
        /// Interaction logic for Win32674841.xaml
        /// </summary>
        public partial class Win32674841 : Window
        {
            public Win32674841()
            {
                InitializeComponent();
    
                ListView1.ItemsSource = DataStore.Names;
            }
    
            private void Button_Click(object sender, RoutedEventArgs e)
            {
                ListView1.ItemTemplate = (DataTemplate)this.Resources["AwesomeTemplate"];
            }
        }
        public class DataStore
          {
             public static List<String> Names { get { return new List<string>() { "Anjum" }; } }
          }
    }
