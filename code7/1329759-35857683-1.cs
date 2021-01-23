    public class RowTemplateSelecter: DataTemplateSelector
    {        
        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            FrameworkElement element = container as FrameworkElement;
            int rows = 1;
            int.TryParse(item.ToString(), out rows);
            switch (rows)
            {
                case 1:
                    return element.FindResource("OneRow") as DataTemplate;
                case 2:
                    return element.FindResource("TwoRows") as DataTemplate;
                case 3:
                    return element.FindResource("ThreeRows") as DataTemplate;
                default:
                    return element.FindResource("OneRow") as DataTemplate;
            }          
        }
    }
