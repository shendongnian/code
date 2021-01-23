        ViewModel vm = new ViewModel();
        vm.List = new ObservableCollection<Person>();
        foreach (var i in Enumerable.Range(1,10))
        {
            vm.List.Add(new Person() { Name = "Test" + i.ToString(), Age= i });
        }
        vm.CurrentPerson = null;
        this.DataContext = vm;
