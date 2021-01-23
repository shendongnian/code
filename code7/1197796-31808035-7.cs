    public ObservableCollection<TabItemVM> Tabs { get; private set; }
    public MainVM()
    {
        Tabs = ObservableCollection<TabItemVM>
        {
            new TabItemVM { Name="Tab 1" },
        };
    }
    void AddTab(){
       var newTab = new TabItemVM { Name="Tab 2" };
       Tabs.Add(newTab);
       //SelectedTab = newTab; //you may bind TabControl.SelectedItemProperty to viewmodel in order to be able to activate the tab from viewmodel
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
