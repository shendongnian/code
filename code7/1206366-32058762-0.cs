    public class StyleSelector : DataTemplateSelector
    {
        public DataTemplate DefaultTemplate
        { get; set; }
        public DataTemplate SeparatorTemplate
        { get; set; }
        public DataTemplate ResetTemplate
        { get; set; }
        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            var type = item as SomeType;
            if (type != null)
            {
                switch (type.SomeItemTypeField)
                {
                    case TypeENum.Separator: return SeparatorTemplate;
                    case TypeENum.Reset: return ResetTemplate;
                    default:
                        return DefaultTemplate;
                }
            }
            return base.SelectTemplate(item, container);
        }
    }
