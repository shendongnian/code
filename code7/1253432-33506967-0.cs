    public class ProductsDataTemplateSelector : DataTemplateSelector
    {
        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            FrameworkElement element = container as FrameworkElement;
    
            if (element != null && item != null && item is Product)
            {
                Product productitem = item as Product;
    
                if (productitem.Code == "1001" || productitem.Code == "1003")
                {
                    return element.FindResource("1001ProductTemplate") as DataTemplate;
                }
                else if (productitem.Code == "1002")
                {
                    return element.FindResource("1002ProductTemplate") as DataTemplate;
                }
                else
                {
                    return element.FindResource("UnknownProductTemplate") as DataTemplate;
                }
            }
    
            return null;
        }
    }
