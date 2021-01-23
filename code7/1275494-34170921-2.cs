    StateVM vm = new StateVM();
    vm.Collection.Add(new CountryStates() { Name = "India", States = new[] { "mp", "up", "tn" }.ToList() });
    vm.Collection.Add(new CountryStates() { Name = "USA", States = new[] { "new york", "washington" }.ToList() });
                
    CountryStateList.DataContext = vm;
...
    private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        ListBox source = (ListBox)(e.OriginalSource);
        System.Diagnostics.Debug.WriteLine(">>>>>> " + ((CountryStates)(source.DataContext)).SelectedState);
    }
