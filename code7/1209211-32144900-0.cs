    private void ViewModelPropertyChanged(object sender, PropertyChangedEventArgs e)
    {
        // Track changes to update sum
        if (e.PropertyName == "A" || e.PropertyName == "B" || e.PropertyName == "C")
        {
            OnPropertyChanged("D");
        }
    }
