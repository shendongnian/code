    public class MainVM : ViewModelBase
    {
        public ObservableCollection<TabItemVM> Tabs { get; private set; }
    
        public MainVM()
        {
            Tabs = new ObservableCollection<TabItemVM>
            {
                new Tab1VM(),
            };
        }
        void AddTab()
        {
            var newTab = new Tab2VM()
            Tabs.Add(newTab);
           //SelectedTab = newTab; 
        }
    }
    
    public class TabItemBase
    {
        public string Name { get; protected set; }
    }
    
    public class Tab1VM : TabItemBase
    {
        public Tab1VM()
        {
            Name = "Tab 1";
        }
    }
    
    public class Tab2VM : TabItemBase
    {
        public Tab2VM()
        {
            Name = "Tab 2";
        }
    }
