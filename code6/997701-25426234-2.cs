    <TabControl ItemsSource="{Binding YourTabItemData}">
        <TabControl.ItemTemplate>
            <DataTemplate>
                <TextBlock Text="{Binding HeaderText}" />
            </DataTemplate>
        </TabControl.ItemTemplate>
        <TabControl.ContentTemplate>
            <DataTemplate>
                <!-- Content -->
            </DataTemplate>
        </TabControl.ItemTemplate>
    </TabControl>
