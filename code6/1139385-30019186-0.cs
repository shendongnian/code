    public class SuspendBehavior : Behavior<THE_TYPE_OF_YOUR_CHART/GRAPH>
    {
        private IDisposable disposable;
        public static readonly DependencyProperty SuspendUpdateProperty = DependencyProperty.Register(
            "SuspendUpdate", typeof(bool), typeof(SuspendBehavior), new PropertyMetadata(default(bool), OnSuspendUpdateChanged));
        public bool SuspendUpdate
        {
            get { return (bool) GetValue(SuspendUpdateProperty); }
            set { SetValue(SuspendUpdateProperty, value); }
        }
        private static void OnSuspendUpdateChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var behavior = d as SuspendBehavior;
            var value = (bool) e.NewValue;
            if (value)
            {
                // AssociatedObject would be your graph
                disposable = behavior.AssociatedObject.SuspendUpdate ...
            }
            else
            {
                if (behavior.disposable != null)
                    behavior.disposable.Dispose();
            }
        }
    }
