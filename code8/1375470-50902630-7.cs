    public sealed class CustomRoundedButton : Button
    {
        private Grid _rootGrid = null;
        public CustomRoundedButton()
        {
            this.DefaultStyleKey = typeof(CustomRoundedButton);
        }
        protected override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            _rootGrid = GetTemplateChild("RootGrid") as Grid;
        }
        public CornerRadius CornerRadius
        {
            get { return (CornerRadius)GetValue(CornerRadiusProperty); }
            set { SetValue(CornerRadiusProperty, value); }
        }
        public static readonly DependencyProperty CornerRadiusProperty =
            DependencyProperty.Register("CornerRadius", typeof(CornerRadius), typeof(CustomRoundedButton), new PropertyMetadata(new CornerRadius(10,10,10,10)));
     
    }
