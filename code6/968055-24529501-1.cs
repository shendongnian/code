      using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Text;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Data;
    using System.Windows.Documents;
    using System.Windows.Input;
    using System.Windows.Media;
    using System.Windows.Media.Imaging;
    using System.Windows.Navigation;
    using System.Windows.Shapes;
    
    namespace WpfApplication1
    {
        /// <summary>
        /// Interaction logic for MainWindow.xaml
        /// </summary>
        public partial class MainWindow : Window
        {
            public MainWindow()
            {
                InitializeComponent();
            }
    
            private void button1_Click(object sender, RoutedEventArgs e)
            {       
                var items = new LotsOfItems();
    
                this.Resources.Add("data", items);
    
                theList.ItemsSource = (LotsOfItems)this.FindResource("data");
    
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
