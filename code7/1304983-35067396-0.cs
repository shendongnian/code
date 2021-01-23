    public partial class Window3 : Window
    {
        private ObservableCollection<Person> people = new ObservableCollection<Person>();
    
        public Window3()
        {
            InitializeComponent();
                            
            people.Add(new Person() { Name = "Paul", Surname = "Green" });
            people.Add(new Person() { Name = "Mike", Surname = "Gray" });
            people.Add(new Person() { Name = "John", Surname = "Black" });
    
            dataGrid.ItemsSource = people;
        }
    
        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataGridRow dataGridRow;
            foreach (Person p in e.AddedItems)
            {
                if (p.Name == "Mike")
                {
                    dataGridRow = dataGrid.ItemContainerGenerator.ContainerFromItem(people[2]) as DataGridRow;
                    dataGridRow.Visibility = System.Windows.Visibility.Collapsed;
                    return;
                }
            }
    
            dataGridRow = dataGrid.ItemContainerGenerator.ContainerFromItem(people[2]) as DataGridRow;
            dataGridRow.Visibility = System.Windows.Visibility.Visible;
        }
    }
