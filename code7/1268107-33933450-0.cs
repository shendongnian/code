    public class ViewSelector : DataTemplateSelector
        {
            public override DataTemplate SelectTemplate(object item, DependencyObject container)
            {
                if (item is Views.Classic_View_Model)
                    return (container as FrameworkElement).FindResource("ClassicViewTemplate") as DataTemplate;
                else if (item is Views.Modern_View_Model)
                    return (container as FrameworkElement).FindResource("ModernViewTemplate") as DataTemplate;
                return null;
            }
        }
