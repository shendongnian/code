    public static readonly DependencyProperty RowsInfoProperty =
        DependencyProperty.Register("RowsInfo", typeof(ObservableCollection<bool>), typeof(MainWindow),
            new FrameworkPropertyMetadata(new ObservableCollection<bool>()));
    public ObservableCollection<bool> RowsInfo
    {
        get { return (ObservableCollection<bool>)GetValue(RowsInfoProperty); }
        set { SetValue(RowsInfoProperty, value); }
    }
