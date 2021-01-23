    public partial class ProductionReport : IDisposable 
    {
        ...
        public bool IsFeatureVisible
        {
            get { return (string)GetValue(IsFeatureVisibleProperty); }
            set { SetValue(IsFeatureVisibleProperty, value); }
        }
        // Using a DependencyProperty as the backing store for IsFeatureVisible.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IsFeatureVisibleProperty =
            DependencyProperty.Register("IsFeatureVisible", typeof(bool), typeof(ButtonControl), new UIPropertyMetadata(false));
        ...
    }
