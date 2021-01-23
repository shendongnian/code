        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            ObservableCollection<MyDataClass> data = new ObservableCollection<MyDataClass>();
            data.Add(new MyDataClass { Code = "Code 1", ID = 1, Name = "Name 1", Type = "Type 1" });
            data.Add(new MyDataClass { Code = "Code 2", ID = 2, Name = "Name 2", Type = "Type 2" });
            data.Add(new MyDataClass { Code = "Code 3", ID = 3, Name = "Name 3", Type = "Type 3" });
            data.Add(new MyDataClass { Code = "Code 4", ID = 4, Name = "Name 4", Type = "Type 4" });
            data.Add(new MyDataClass { Code = "Code 5", ID = 5, Name = "Name 5", Type = "Type 5" });
            dataGrid1.ItemsSource = data;
        }
