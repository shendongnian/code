    public class ControlBackgroundColorBehavior : DependencyObject, IBehavior
    {
        private Control _contentDialog;
        public void Detach()
        {
            _contentDialog.IsEnabledChanged -= OnIsEnabledChanged;
        }
        DependencyObject IBehavior.AssociatedObject { get; }
        public DependencyObject AssociatedObject { get; private set; }
        public void Attach(DependencyObject associatedObject)
        {
            AssociatedObject = associatedObject;
            _contentDialog = AssociatedObject as ContentDialog;
            _contentDialog.IsEnabledChanged += OnIsEnabledChanged;
        }
        public Brush DisabledForegroundColor { get; set; }
        private void OnIsEnabledChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (!Equals(e.NewValue, true))
            {
                _contentDialog.Foreground= DisabledForegroundColor ;
            }
            else
            {
                _contentDialog.Foreground= (Brush)Control.ForegroundProperty.GetMetadata(typeof(Control)).DefaultValue;
            }
        }
    }
