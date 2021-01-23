    public class ShowEmptySign : Behavior<ItemsControl>
    {
        private TextBlock msg;
        ...OnAttached()
        {
            var rootGrid=AssociatedObject.GetDecendant<Grid>();
            msg = new TextBlock(){...};
            rootGrid.Children.Add(msg)
            ((INotifyCollectionChanged)AssociatedObject.Items).CollectionChanged += CheckIfEmpty
            CheckIfEmpty();
        }
        ...CheckIfEmpty()
        {
            if(!AssociatedObject.Items.Any()) Show(); else Hide();
        }
        ...Show()
        {
            msg.Visibility = Visibility.Visible;
        }
    }
