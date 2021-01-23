    public class NameTemplateSelector : PropertyTemplateSelector
    {
        protected override DataTemplate SelectTemplateImpl(object propertyValue, DependencyObject container)
        {
            string name = (string)propertyValue;
    
            if (name != null && name.StartsWith("A", StringComparison.OrdinalIgnoreCase))
            {
                return (DataTemplate)App.Current.MainWindow.FindResource("VipName");
            }
    
            return (DataTemplate)App.Current.MainWindow.FindResource("NormalName");
        }
    }
