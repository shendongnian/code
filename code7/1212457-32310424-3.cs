     public class SomeTemplateSelector : DataTemplateSelector
    {
        public DataTemplate OthersTemplate { get; set; }
        public DataTemplate DefaultTemplate { get; set; }
        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            return DefaultTemplate;
        }
    }
