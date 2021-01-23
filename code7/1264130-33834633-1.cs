    public BitmapImage Icon
    {
       get { return _Icon; }
       set{ _Icon = value; NotifyPropertyChanged(); }
    }
    Icon = new BitmapImage(new Uri(@"../images/Pencil-01.png", UriKind.Relative));
