    public class CustomDataTemplateSelector : DataTemplateSelector
    {
        public DataTemplate NoInkCanvas
        {
            get;
            set;
        }
    
        public DataTemplate InkCanvas
        {
            get;
            set;
        }
    
        protected override DataTemplate SelectTemplateCore(object item, DependencyObject container)
        {
            var canvas = item as HandwritingControl;
            if (canvas == null)
            {
                return this.NoInkCanvas;
            }
            else
            {
                return InkCanvas;
            }
        }
    }
