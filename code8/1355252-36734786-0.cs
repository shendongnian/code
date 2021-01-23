    public class MyClass : DependencyObject
    {
        public double HeightReplica
        {
            get { return (double)GetValue(HeightReplicaProperty); }
            set { SetValue(HeightReplicaProperty, value); }
        }
        // Using a DependencyProperty as the backing store for HeightReplica.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty HeightReplicaProperty =
            DependencyProperty.Register("HeightReplica", typeof(double), typeof(MyClass), new UIPropertyMetadata(new PropertyChangedCallback(HeightReplicaChanged)));
        public static void HeightReplicaChanged(DependencyObject DO, DependencyPropertyChangedEventArgs e)
        {
           //value change detected
        }
    }
