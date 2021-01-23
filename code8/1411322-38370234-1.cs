    private void Tab_add_MouseUp(object sender, MouseButtonEventArgs e)
    {
        e.Handled = true;
        // Only add if the user clicks on the last items.
        if (this.SelectedIndex == this.Tabs.Count - 1)
        {
            TabItem tabItem = new TabItemDepartment("Header #x");
            this.Tabs.Insert(this.Tabs.Count - 1, tabItem);
            // The Count has changed at this point so make sure we check the collection again.
            this.SelectedIndex = this.Tabs.Count - 2;
        }
    }
