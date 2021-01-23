    public class MyTemplateSelector : DataTemplateSelector
    {
        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            if (item is string)
                return ((FrameworkElement) container).FindResource("TextTemplate") as DataTemplate;
            else
                return ((FrameworkElement)) container).FindResource("EnumTemplate") as DataTemplate;             
        }
    }
