    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            var list = new List<ListItem>
             {
                new ListItem{ Value = 1, Text = "Smith" },
                new ListItem{ Value = 12, Text = "John" } ,
                new ListItem{ Value = 14, Text = "Bon" }
            }.ToList();
            listCombobox.ItemsSource = list;
            listCombobox.DisplayMemberPath = "Text";
            listCombobox.SelectedValuePath = "Value";
        }
        private void listCombobox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedItem = (sender as ComboBox).SelectedItem as ListItem;
            if (selectedItem != null)
            {
                // do something with the selected item
            }
        }
    }
    public class ListItem
    {
        public string Text { get; set; }
        public int Value { get; set; }
    }
    
