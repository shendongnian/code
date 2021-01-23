    // using the one declared in xaml file
    
        CViewModel vm = (CViewModel)this.DataContext;
        vm.topGrid = TopGrid;
    // using a new one
    
    CViewModel vm = new CViewModel();
    vm.topGrid = TopGrid;    
    this.DataContext = vm;
