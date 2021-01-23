    <ContextMenu DataContext="{Binding PlacementTarget.DataContext, RelativeSource={RelativeSource Self}}">
    <MenuItem Header="Show/Hide Columns" 
        ItemsSource="{Binding Columns}">
        <MenuItem.ItemTemplate>
             <DataTemplate>
                  <TextBlock Text="{Binding Header}"></TextBlock>
             </DataTemplate>
        </MenuItem.ItemTemplate>
    </MenuItem>
    </ContextMenu>
