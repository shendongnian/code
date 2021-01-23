    using System.Collections.ObjectModel;
    using System.Windows;
    
    namespace WpfApplication4
    {
        /// <summary>
        ///     Interaction logic for MainWindow.xaml
        /// </summary>
        public partial class MainWindow : Window
        {
            public MainWindow()
            {
                InitializeComponent();
                DataContext = new ItemCollection
                {
                    new Item
                    {
                        Text = "A",
                        Items = new ItemCollection
                        {
                            new Item
                            {
                                Text = "B",
                                Items = new ItemCollection
                                {
                                    new Item
                                    {
                                        Text = "C"
                                    }
                                }
                            }
                        }
                    }
                };
            }
        }
    
        public class Item
        {
            public string Text { get; set; }
    
            public ItemCollection Items { get; set; }
        }
    
        public class ItemCollection : ObservableCollection<Item>
        {
        }
    }
