    public ObservableCollection<BankMovement> Movements { get; set; }
    Movements = new ObservableCollection<BankMovement>();
    Movements.Add(new BankMovement());
    // add as many movements as you want
    //tabControl1.ItemsSource = Movements;  You can do this through Binding in the XAML, preferably
