     class TreeViewTemplateSelector : DataTemplateSelector
    {
        public DataTemplate BasicTemplate { get; set; }
        public DataTemplate ComplexTemplate { get; set; }
        public DataTemplate RootTemplate { get; set; }
        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            if (item is MyBasicData) return BasicTemplate;
            if (item is MyComplexData) return ComplexTemplate;
            if (item is MyRootData) return RootTemplate;
            return null;
        }
    }
