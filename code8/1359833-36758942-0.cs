    <ListView ItemsSource="{Binding items}">
        <ListView.ItemTemplate>
            <DataTemplate>
                <StackPanel>
                    <Label Content="{Binding text}" />
                    <ListView ItemsSource="{Binding strings}">
                        <ListView.ItemTemplate>
                            <DataTemplate>
                                <Label Content="{Binding}" />
                            </DataTemplate>
                        </ListView.ItemTemplate>
                    </ListView>
                </StackPanel>
            </DataTemplate>
        </ListView.ItemTemplate>
    </ListView>
