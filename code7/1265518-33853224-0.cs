    public static readonly DependencyProperty PointsProperty = DependencyProperty.Register(
            "Points", typeof (ObservableCollection<Point>), typeof (Line), new PropertyMetadata(default(ObservableCollection<Point>)));
    
        public ObservableCollection<Point> Points
        {
            get { return (ObservableCollection<Point>) GetValue(PointsProperty); }
            set { SetValue(PointsProperty, value); }
        }
