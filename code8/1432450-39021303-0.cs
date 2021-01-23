    public class MyDataTemplateSelector : DataTemplateSelector
    {
        public DataTemplate CategoryTemplate { get; set; }
        public DataTemplate MenuTemplate { get; set; }
        public DataTemplate PlateTemplate { get; set; }
    
        protected override DataTemplate SelectTemplateCore(object item, DependencyObject container)
        {
            if (item is CategoriesViewModel)
            {
                return CategoryTemplate;
            }
            else if (item is MenuItemsViewModel)
            {
                return MenuTemplate;
            }
            else if (item is PlatesViewModel)
            {
                return PlateTemplate;
            }
            else
            {
                return base.SelectTemplateCore(item);
            }
        }
    }
