    <TabControl ItemsSource="{Binding PageViews}" SelectedIndex="0">
        <TabControl.Resources>
            <DataTemplate DataType="{x:Type namespace:MembersViewModel}">
                <namespace:MembersView />
            </DataTemplate>
            <DataTemplate DataType="{x:Type namespace:ClassesViewModel}">
                <namespace:ClassesView />
            </DataTemplate>
            <DataTemplate DataType="{x:Type namespace:SessionsViewModel}">
                <namespace:SessionsView />
            </DataTemplate>
        </TabControl.Resources>
        <TabControl.ItemTemplate>
            <DataTemplate>
                <TextBlock Text="{Binding TabTitle}}" />
            </DataTemplate>    
        </TabControl.ItemTemplate>
    </TabControl>
