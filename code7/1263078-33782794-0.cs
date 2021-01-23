    tabControl.SelectedIndexChanged += (sender, e) =>
    {
        if (tabControl.SelectedIndex == 4)
        {
            this.AutoScrollPosition = new Point(0,0);
            tabControl.SelectedTab.AutoScrollPosition = new Point(0, 0);
        }
    };
