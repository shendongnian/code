        public class MainVM
        {
            public TabItemBase[] Tabs { get; private set; }
            public MainVM()
            {
                Tabs = new TabItemBase[]
                {
                    new Tab1VM (),
                    new Tab2VM (),
                };
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
