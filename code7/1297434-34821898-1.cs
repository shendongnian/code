     public class LazyButton : Button
    {
        public static readonly DependencyProperty DataProperty = DependencyProperty.Register("Data", typeof(Geometry), typeof(LazyButton), new PropertyMetadata(new PropertyChangedCallback(OnDataChanged)));
        private static void OnDataChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            LazyButton button = d as LazyButton;
            button.Content = new Path() { Data = e.NewValue as Geometry, Fill = Brushes.Gray, Stretch = Stretch.Uniform };
        }
        public Geometry Data
        {
            get { return (Geometry)GetValue(DataProperty); }
            set { SetValue(DataProperty, value); }
        }
    }
