    public class RaOrthogonalLine : Canvas
    {
        public INotifyCollectionChanged Points
        {
            get { return (INotifyCollectionChanged)GetValue(PointsProperty); }
            set { SetValue(PointsProperty, value); }
        }
    
    
        public static readonly DependencyProperty PointsProperty =
            DependencyProperty.Register("Points", typeof(INotifyCollectionChanged), typeof(RaOrthogonalLine),
            new FrameworkPropertyMetadata(null, new PropertyChangedCallback(PointsPropertyChanged))
            {
                BindsTwoWayByDefault = true,
                DefaultUpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged
            });
    
        void Points_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            Paint();
        }
    
        private static void PointsPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            RaOrthogonalLine raOrthogonalLine = (RaOrthogonalLine)d;
            INotifyCollectionChanged newValue = (INotifyCollectionChanged)e.NewValue;
            INotifyCollectionChanged oldValue = (INotifyCollectionChanged)e.OldValue;
    
            if (oldValue != null)
            {
                oldValue.CollectionChanged -= raOrthogonalLine.Points_CollectionChanged;
            }
    
            if (newValue != null)
            {
                newValue.CollectionChanged += raOrthogonalLine.Points_CollectionChanged;
            }
            raOrthogonalLine.Paint();
        }
    }
