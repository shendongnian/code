        this.TabItems = new ObservableCollection<TabItem>
        {
            new TabItem("Main", new MainControl()), 
            new TabItem("Tab1", new GenericTabControl(new ViewModel1())),
            new TabItem("Tab2", new GenericTabControl(new ViewModel2()))
        };
