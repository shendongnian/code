    using System.Windows.Interactivity;
    private void ClearTable_Click(object sender, RoutedEventArgs e)
    {
        var menuItem = (MenuItem)sender; //MenuItem that fired the click event
        var contextMenu = menuItem.GetSelfAndAncestors().OfType<ContextMenu>().First()
        UIElement sourceControl = menu.PlacementTarget;
    }
