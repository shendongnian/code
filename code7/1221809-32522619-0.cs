    ((INotifyPropertyChanged)x).PropertyChanged +=
            new PropertyChangedEventHandler(Expando_PropertyChanged);
        x.NewProp = string.Empty;
    private static void Expando_PropertyChanged(object sender,
        PropertyChangedEventArgs e)
    {
        Console.WriteLine("{0} has changed.", e.PropertyName);
    }
