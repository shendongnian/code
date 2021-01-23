    <DataGrid x:Name="AllLogs">
        <DataGrid.ContextMenu>
            <ContextMenu>
                <MenuItem Header="Show/Hide Columns" 
                          ItemsSource="{Binding PlacementTarget.Columns, RelativeSource={RelativeSource AncestorType=ContextMenu}}">
                    <MenuItem.ItemTemplate>
                        <DataTemplate>
                            <TextBlock Text="{Binding Header}"/>
                        </DataTemplate>
                    </MenuItem.ItemTemplate>
                </MenuItem>
            </ContextMenu>
        </DataGrid.ContextMenu>
    </DataGrid>
