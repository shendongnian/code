    <TabControl ItemsSource="{Binding Items}">
        <!-- // If you only need to display a single property, you can use DisplayMemberPath.
             // If you need something more fancy (such as a text-block and button next to each other),
             // you'll have to provide a tab header template instead: -->
        <TabControl.ItemTemplate>
            <DataTemplate>
                <!-- // Tab item header template (this is how each tab header will look): -->
                <StackPanel Orientation="Horizontal">
                    <TextBlock Text="{Binding TabHeaderName}" />
                    <Button Content="X"
                            Command="{Binding DataContext.RemoveTabCommand, RelativeSource={RelativeSource AncestorType=TabControl}}"
                            CommandParameter="{Binding}" />
                </StackPanel>
            </DataTemplate>
        </TabControl.ItemTemplate>
        <TabControl.ContentTemplate>
            <DataTemplate>
                <!-- // Tab item content template (this is how each tab content will look): -->
                <Image Source="{Binding TabImagePath}" />
            </DataTemplate>
        </TabControl.ContentTemplate>
    </TabControl>
