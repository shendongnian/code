    var a = new ViewModelA();
    var b = new ViewModelB() { SomeProperty = "Test" };
    // display a - will display UserControlA content in ContentControl
    SelectedViewModel = a;
    OnPropertyChanged(nameof(SelectedViewModel));
    // display b - will display text and button in ContentControl
    SelectedViewModel = b;
    OnPropertyChanged(nameof(SelectedViewModel));
