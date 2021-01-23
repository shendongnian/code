    ObservableCollection<State> items = new ObservableCollection<State>();
        foreach (string col in columns)
        {
            items.Add(new State()
            {
                Name = col,
                Include = true,
                Measure = string.Empty  // Initialize it to whatever you want
            });
        }
        DataContext = items;
