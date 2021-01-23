    public class ItemTemplateSelector : DataTemplateSelector
    {
        public DataTemplate ParentTemplate { get; set; }
        public DataTemplate ChildTemplate { get; set; }
        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            var element = item as XElement;
            if (element != null)
            {
                return element.Elements().Any() ? ParentTemplate : ChildTemplate;
            }
            return base.SelectTemplate(item, container);
        }
    }
