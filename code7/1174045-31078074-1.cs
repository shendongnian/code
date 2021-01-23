    public class MyContentTemplateSelector : DataTemplateSelector
    {
        public DataTemplate AlphaTemplate { get; set; }
        public DataTemplate BetaTemplate { get; set; }
        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            if (item is SubViewModelAlpha) 
                return AlphaTemplate;
            if (item is SubViewModelBeta)
                return BetaTemplate;
            return base.SelectTemplate(item, container);
        }
    }
