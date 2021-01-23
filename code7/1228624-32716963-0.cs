            var tabs = new ObservableCollection<MyTab>();
            int tabsCount = 5;
            for (var i = 1; i <= tabsCount; i++)
            {
                var tab = new MyTab() {Header = "Tab " + i};
                tab.Data.Add(new MyTabData() {Column1 = "col1" + i, Column2 = "col2" + i, Column3 = "col3" + i});
                tabs.Add(tab);
            }
            DataContext = tabs;
