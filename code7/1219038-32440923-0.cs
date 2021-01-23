    ObservableCollection<CarType> originalCopy;
    public MainWindow()
    {
        cars = new Cars();
        originalCopy = new ObservableCollection<CarType>(from x in cars.Items select (CarType)x.Clone());
        ....
    }
