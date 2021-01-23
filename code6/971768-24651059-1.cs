    <TabControl ItemsSource="{Binding ViewModelCollection}">
        <TabControl.ItemTemplate>
            <DataTemplate>
                <TextBlock Text="{Binding Name}"/>
            </DataTemplate>
        </TabControl.ItemTemplate>
        <TabControl.ContentTemplate>
            <DataTemplate>
                <Grid>
                    <TextBlock Text="{Binding Description}"/>
                </Grid>
            </DataTemplate>
        </TabControl.ContentTemplate>
    </TabControl>
