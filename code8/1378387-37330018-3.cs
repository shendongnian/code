    public class EquipmentTemplateSelector : DataTemplateSelector
    {
        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            Window win = Application.Current.MainWindow;
            Object resKey = null;
            //  ************************************
            //  Do stuff here to pick a resource key
            //  ************************************
            //  Application.Current.Resources is ONE resource dictionary.
            //  Use FindResource to find any resource in scope. 
            return win.FindResource(resKey) as DataTemplate;
        }
    }
