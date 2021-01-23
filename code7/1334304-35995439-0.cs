    public static readonly DependencyProperty CinProperty = 
         DependencyProperty.Register("Cin", typeof(Citati),
         typeof(MainPage), new FrameworkPropertyMetadata(null));
    
    public Citati Cin
    {
        get { return (Citati)GetValue(CinProperty); }
        set { SetValue(CinProperty, value); }
    }
    private void btnPopulate_Click(object sender, RoutedEventArgs e)
    {
        var dat = DateTime.Now;
        var cit = new Citati();
        int dan = dat.DayOfYear;
        cit.Citiranje(dan);
        stpCitat.DataContext = cit;
        Cit = cit;
    }
