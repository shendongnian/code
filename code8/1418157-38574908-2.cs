    public class TemplateSelector : DataTemplateSelector
    {
            
        //You override this function to select your data template based in the given item
        public override System.Windows.DataTemplate SelectTemplate(object item, 
                        System.Windows.DependencyObject container)
        {
            if(item is MyViewModel1)
                return DataTemplate1;
            if(item is MyViewModel2)
                return DataTemplate2;
            return base.SelectTemplate(item, container);
        }
    }
