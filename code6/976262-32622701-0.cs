    public static readonly BindableProperty ListItemTappedCommandProperty = BindableProperty.CreateAttached<AttachedProperties, ICommand>(
        staticgetter: o => (ICommand) o.GetValue(ListItemTappedCommandProperty), 
        defaultValue: default(ICommand),
        propertyChanged: (o, old, @new) =>
        {
            var lv = o as ListView;
            if (lv == null) return;
            lv.ItemTapped -= ListView_ItemTapped;
            lv.ItemTapped += ListView_ItemTapped;
        });
    private static void ListView_ItemTapped(object sender, object item)
    {
        var lv = sender as ListView;
        var command = (ICommand) lv?.GetValue(ListItemTappedCommandProperty);
        if (command == null) return;
        if (command.CanExecute(item))
            command.Execute(item);
    }
