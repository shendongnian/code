    public class CustomTemplateSelector : DataTemplateSelector
    {
        public DataTemplate Template1{get;set;}
        public DataTemplate Template2{get;set;}
        public DataTemplate Template3{get;set;}
        public DataTemplate Template4{get;set;}
        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            if(item is float)
                return Template1;
            else if(item is int)
                return Template1;
            else if(item is string)
                return Template2;
            else if(item is bool)
                return Template3;
            //etc
            else
                return Template4;
        }
    }
