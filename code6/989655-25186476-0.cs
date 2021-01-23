    <GridViewColumn Header="{Binding ColumnHeader}" Width="100">
        ...
    </GridViewColumn>
...
    MenuItem mi = sender as MenuItem;
    var menu = mi.Parent as ContextMenu;
    if (menu != null)
    {
        string columnHeader = ColumnHeader;
        ...
    }
