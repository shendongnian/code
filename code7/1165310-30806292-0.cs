    void myChild_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
    {
        if (e.PropertyName == "Quantity")
           OnPropertyChanged("TotalQuantity");
    }
