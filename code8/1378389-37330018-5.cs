    public class EquipmentTemplateSelector : DataTemplateSelector
    {
        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            //  container is the container. Cast it to something you can call
            //  FindResource() on. Put in a breakpoint and use the watch window. 
            //  I'm at work with Windows 7. Shouldn't be too hard.
            var whatever = container as SomethingOrOther;
            Object resKey = null;
            //  ************************************
            //  Do stuff here to pick a resource key
            //  ************************************
            //  Application.Current.Resources is ONE resource dictionary.
            //  Use FindResource to find any resource in scope. 
            return whatever.FindResource(resKey) as DataTemplate;
        }
    }
