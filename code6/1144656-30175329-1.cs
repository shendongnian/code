    public class MyTemplateSelector : DataTemplateSelector
    {
        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            CustomPropertyWrapper cpw = item as CustomPropertyWrapper;
            if (cpw != null)
            {
                if (cpw.PropertyValue is string)
                    return ((FrameworkElement) container).FindResource("TextTemplate") as DataTemplate;
                else
                    return ((FrameworkElement)) container).FindResource("EnumTemplate") as DataTemplate;
            }
            
            return base.SelectTemplate(item, container);
        }
    }
