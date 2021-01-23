    public class VirtualizationNullTemplateSelector : DataTemplateSelector
    {
        public DataTemplate NullTemplate { get; set; }
        public DataTemplate Template { get; set; }
        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            if (item == null)
            {
                return NullTemplate;
            }
            else
            {
                return Template;
            }
        }
    }
