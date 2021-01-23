    public MainWindow()
            {
                InitializeComponent();
                MultiBinding mb = new MultiBinding();
    
                Binding bind = new Binding("ActualWidth");
                bind.Source = control;
    
                mb.Bindings.Add(bind);
    
                bind = new Binding("ActualHeight");
                bind.Source = control;
    
                mb.Bindings.Add(bind);
                mb.Converter = new converter();
    
                pg.SetBinding(Polygon.PointsProperty, mb);
            }
 
    class converter : IMultiValueConverter
        {
         
            public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
            {
                try
                {
                    double width = (double)values[0];
                    double height = (double)values[1];
    
                    PointCollection pc = new PointCollection();
                    pc.Add(new Point(0, 0));
                    pc.Add(new Point(width - 10, height - 10));
                    return pc;
                }
                catch
                {
                    return null;
                }
            }
    
            public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
            {
                throw new NotImplementedException();
            }
        }
