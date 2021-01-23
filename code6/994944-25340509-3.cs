    [TemplatePart(Name = BorderTestTemplatePartName, Type = typeof(Border))]
    public sealed class CustomControl1 : Control
    {
        private const string BorderTestTemplatePartName = "BorderNameTest";
        private Border _myBorder;
       public static readonly DependencyProperty IsFancyLookEnabledProperty = DependencyProperty.Register(
            "IsFancyLookEnabled", typeof (bool), typeof (CustomControl1), new PropertyMetadata(default(bool)));
        public bool IsFancyLookEnabled
        {
            get { return (bool) GetValue(IsFancyLookEnabledProperty); }
            set { SetValue(IsFancyLookEnabledProperty, value); }
        } 
        public CustomControl1()
        {
            this.DefaultStyleKey = typeof(CustomControl1);
        }
        protected override void OnApplyTemplate()
        {
            _myBorder = GetTemplateChild(BorderTestTemplatePartName) as Border;
            // attach events etc. (you can detach them using for example Unloaded event)
            
            base.OnApplyTemplate();
        }
    }
