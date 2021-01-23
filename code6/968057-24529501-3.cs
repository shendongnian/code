    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.IO;
    using System.Linq;
    using System.Runtime.InteropServices.WindowsRuntime;
    using Windows.Foundation;
    using Windows.Foundation.Collections;
    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Controls;
    using Windows.UI.Xaml.Controls.Primitives;
    using Windows.UI.Xaml.Data;
    using Windows.UI.Xaml.Input;
    using Windows.UI.Xaml.Media;
    using Windows.UI.Xaml.Navigation;
    
    // The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238
    
    namespace VirtualizingStackPanelTest
    {
        /// <summary>
        /// An empty page that can be used on its own or navigated to within a Frame.
        /// </summary>
        public sealed partial class MainPage : Page
        {
            public MainPage()
            {
                this.InitializeComponent();
    
                this.NavigationCacheMode = NavigationCacheMode.Required;
            }
    
           
    
            private void button1_Click(object sender, RoutedEventArgs e)
            {
                var items = new LotsOfItems();
    
                this.Resources.Add("data", items);
    
                theList.ItemsSource = (LotsOfItems)this.Resources["data"];
    
            }
        }
    
        public class LotsOfItems : ObservableCollection<String>
        {
            public LotsOfItems()
            {
                for (int i = 0; i < 1000; ++i)
                {
                    Add("item " + i.ToString());
                }
            }
        }
    }
