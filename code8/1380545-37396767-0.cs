      private void Button_Click(object sender, RoutedEventArgs e)
        {
            var nameBinding = new Binding("Name")
            {
                Mode = BindingMode.Default,
                UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged
            };
    
            var ageBinding = new Binding("Age")
            {
                Mode = BindingMode.Default,
                UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged
            };
    
            var dataGrid = new DataGrid();
            dataGrid.Columns.Add(new DataGridTextColumn
            {
                Header = "Name",
                Binding = nameBinding
            });
            dataGrid.Columns.Add(new DataGridTextColumn
            {
                Header = "Age",
                Binding = ageBinding
            });
            dataGrid.ItemsSource = new ObservableCollection<Info>
            {
                new Info
                {
                    Name = "Name 1",
                    Age = "100"
                }
            };
    
            MainGrid.Children.Add(dataGrid);
        }
    
        public class Info
        {
            public string Name { get; set; }
            public string Age { get; set; }
        }
