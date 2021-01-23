    public class MyTemplateSelector : DataTemplateSelector
    {
        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            FrameworkElement element = (FrameworkElement)container;
            if (item == null)
                return (DataTemplate)element.FindResource("NullTemplate");
            else
                return (DataTemplate)element.FindResource("ItemTemplate");
        }
    }
