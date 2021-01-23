    <TabControl ItemsSource="{Binding Items}">
        <TabControl.ItemTemplate>
            <DataTemplate>
                <!-- Tab item header: -->
                <StackPanel Orientation="Horizontal">
                    <TextBlock Text="{Binding DisplayName}" />
                    <Button Content="X" />
                </StackPanel>
            </DataTemplate>
        </TabControl.ItemTemplate>
        <TabControl.ContentTemplate>
            <DataTemplate>
                <!-- Tab item content goes here. -->
            </DataTemplate>
        </TabControl.ContentTemplate>
    </TabControl>
