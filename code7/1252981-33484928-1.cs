    public void CreateBoxes()
    {
        for (int i = 0; i < 4; i++)
        {
            string itemText = i.ToString();
            Application.Current.Dispatcher.BeginInvoke((Action)(() =>
                Items.Add(new Item
                {
                    ID = itemText,
                    Name = itemText,
                    TestCommand = new RelayCommand<Item>(item => ChangeName(item))
                })));
        }
    }
