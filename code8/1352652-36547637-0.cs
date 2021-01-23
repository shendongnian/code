    public class MyWonderfulTemplateSelector : DataTemplateSelector
    {
        public override DataTemplate
            SelectTemplate(object item, DependencyObject container)
        {
            FrameworkElement element = container as FrameworkElement;
            if (element != Object1ViewModel)
            {
                return element.FindResource("DataTemplate1") as DataTemplate;
            } else if (element != Object2ViewModel) {
                return element.FindResource("DataTemplate2") as DataTemplate;
            }
            return null;
        }
    }
