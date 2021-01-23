	protected virtual void OnCollectionChanged(NotifyCollectionChangedEventArgs e)
    {
        this.RaiseCollectionChanged(e);
        RaisePropertyChanged(new PropertyChangedEventArgs("Count"));
    }
