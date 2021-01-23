    protected override void OnSomeBusinessCurrentEntityPropertyChanged(object sender, PropertyChangedEventArgs e)
    {
        base.OnSomeBusinessCurrentEntityPropertyChanged(sender, e);
        if (sender is TimeSheet)
             this.OnPropertyChanged("Total")
    }
   
