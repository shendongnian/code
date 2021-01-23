     ObservableCollection<User> users = new ObservableCollection<User>();
     List<String> lst = new List<string>();
     lst.Add("AAA");
     lst.Add("BBB");
     lst.Add("CCC");
     users.Add(new User() { Id = 1, Name = "John Doe", Str = lst });
     dg.ItemsSource = users;
