    ViewModel vm = new ViewModel();
    
    // removing 2 items and reassigning DataContext to viewmodel.
    private void Button_Click(object sender, RoutedEventArgs e)
    {
        Dgrid.DataContext = null;
        vm.Students.RemoveAt(1);
        vm.Students.RemoveAt(2);
        Dgrid.DataContext = vm;
    }
