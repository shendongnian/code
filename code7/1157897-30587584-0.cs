    <TabControl ItemsSource="{Binding Pages}">
        <TabControl.ItemTemplate>
            <DataTemplate>
                <TextBlock Text="{Binding DisplayName}" />
            </DataTemplate>
        </TabControl.ItemTemplate>
        <TabControl.Resources>
            <!-- Use curly braces for x:Type markup extension -->
            <DataTemplate DataType="{x:Type vm:FirstPageModel}">
                <v:FirstPageView />
            </DataTemplate>
            <DataTemplate DataType="{x:Type vm:SecondPageModel}">
                <v:SecondPageView />
            </DataTemplate>
        </TabControl.Resources>
    </TabControl>
