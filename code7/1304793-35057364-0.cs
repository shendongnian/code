    public class BlockItem
    {
        // TODO
    }
    public class BoxItem
    {
        // TODO
    }
    public class MyTemplateSelector : DataTemplateSelector
    {
        public DataTemplate BlockTemplate { get; set; }
        public DataTemplate BoxTemplate { get; set; }
        protected override DataTemplate SelectTemplateCore(object item)
        {
            if (item is BlockItem) return BlockTemplate;
            else if (item is BoxItem) return BoxTemplate;
            return base.SelectTemplateCore(item);
        }
    }
