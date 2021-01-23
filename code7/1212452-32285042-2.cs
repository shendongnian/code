    public class ValueDataTemplateSelector : DataTemplateSelector
        {
            public DataTemplate DefaultTemplate { get; set; }
            public DataTemplate OthersTemplate { get; set; } 
    
            public override DataTemplate SelectTemplate(object item, System.Windows.DependencyObject container)
            {
                DataTemplate template = DefaultTemplate;
    
                CheckList data = item as CheckList;
                if (data.Description.Contains("Others"))
                {
                    template = OthersTemplate;
                }
    
                return template;
            }
        
        }
