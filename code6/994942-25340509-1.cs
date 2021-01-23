    [TemplatePart(Name = BorderTestTemplatePartName, Type = typeof(Border))]
    public sealed class CustomControl1 : Control
    {
        private const string BorderTestTemplatePartName = "BorderNameTest";
        private Border _myBorder;
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
