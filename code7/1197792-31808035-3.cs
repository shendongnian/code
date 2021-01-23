    public TabItemVM[] Tabs { get; private set; }
    public MainVM()
    {
        Tabs = new[]
        {
            new TabItemVM { Name="Tab 1" },
            new TabItemVM { Name="Tab 2" },
        };
    }
    public class TabItemTemplateSelector : DataTemplateSelector
    {
        public DataTemplate Tab1Template { get; set; }
        public DataTemplate Tab2Template { get; set; }
        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            var tabItem = item as TabItemVM;
            if (tabItem.Name == "Tab 1") return Tab1Template;
            if (tabItem.Name == "Tab 2") return Tab2Template;
            return base.SelectTemplate(item, container);
        }
    }
