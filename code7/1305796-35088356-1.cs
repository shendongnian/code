    protected override void OnPropertyChanged(DependencyPropertyChangedEventArgs e)
    {
        if (e.Property.Name == "DataContext" && e.NewValue.ToString() == "{DisconnectedItem}")
        {
            System.Diagnostics.Debug.WriteLine(this + " : I am removed !");
        }
        base.OnPropertyChanged(e);
    }
