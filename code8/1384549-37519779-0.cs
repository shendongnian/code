    public MyClass()
    {
        myStrings = new ObservableCollection<string>();
        myControl.ItemsSource = myStrings;
    }
    
    private void AddNewItem(string item)
    {
        myStrings.Add(item);
    }
