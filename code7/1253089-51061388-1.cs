    <DataGrid.ContextMenu>
        <ContextMenu DataContext="{Binding PlacementTarget, RelativeSource={RelativeSource Self}}">
            <MenuItem Header="Show/Hide Columns" ItemsSource="{Binding Columns}">
                <MenuItem.ItemTemplate>
                    <DataTemplate>
                        <TextBlock Text="{Binding Header}"/>
                    </DataTemplate>
                </MenuItem.ItemTemplate>
            </MenuItem>
        </ContextMenu>
    </DataGrid.ContextMenu>
