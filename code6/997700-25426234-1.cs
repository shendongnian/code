    <TabControl ItemsSource="{Binding YourTabItemData}" SelectedItem="{Binding YourItem}">
        ...
    </TabControl>
...
    public YourTabItemDataClass YourItem
    {
        get { return yourItem; }
        set 
        {
            yourItem = value; 
            NotifyPropertyChanged(); 
            // Selected TabItem has just changed
            string headerOfSelectedTab = yourItem.HeaderText;
        }
    }
