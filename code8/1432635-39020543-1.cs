    <GridViewColumn.CellTemplate>
        <DataTemplate>
            <Button
                Content="Edit"
                Command="{Binding DataContext.EditItemCommand, RelativeSource={RelativeSource AncestorType=ListView}}"
                CommandParameter="{Binding}"
                IsEnabled="{Binding IsSelected, RelativeSource={RelativeSource AncestorType=ListViewItem}}"
                />
        </DataTemplate>
    </GridViewColumn.CellTemplate>
