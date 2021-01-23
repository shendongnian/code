    public class CategoryBrandItemTemplateSelector : DataTemplateSelector
    {
        public DataTemplate CategoryItemTemplate { get; set; }
        public DataTemplate BrandItemTemplate { get; set; }
    
        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            if(item is Category)
                return CategoryItemTemplate;
                
            if(item is Brand)
                return BrandItemTemplate;
    
            return base.SelectTemplate(item, container);
        }
    }
