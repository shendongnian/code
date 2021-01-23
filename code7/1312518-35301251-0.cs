    public static readonly DependencyProperty HourListProperty =
        DependencyProperty.Register("HourList",
        typeof(ObservableCollection<int>), typeof(MyUserControl1), 
        new PropertyMetadata(new ObservableCollection<int> 
        { 
          0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 
          14, 15, 16, 17, 18, 19, 20, 21, 22, 23 
        }));
    public ObservableCollection<int> HourList
    {
        get
        {
            return (ObservableCollection<int>)this.GetValue(HourListProperty);
        }
        set
        {
            this.SetValue(HourListProperty, value); 
        }
    }
