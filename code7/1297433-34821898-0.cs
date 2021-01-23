     public class LazyButton : Button
    {
        public static readonly DependencyProperty DataProperty = DependencyProperty.Register("Data", typeof(Geometry), typeof(LazyButton), new PropertyMetadata(null));
        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            this.Content = new Path() { Data = this.Data, Fill = Brushes.Gray, Stretch = Stretch.Uniform };
        }
        public Geometry Data
        {
            get { return (Geometry)GetValue(DataProperty); }
            set { SetValue(DataProperty, value); }
        }
    }
