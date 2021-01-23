    public class ExtendedListView : ListView
    {
        protected override void OnKeyDown(KeyRoutedEventArgs e)
        {
            if (e.Key == VirtualKey.Enter || e.Key == VirtualKey.Up || e.Key == VirtualKey.Down)
            {
                return;
            }
            base.OnKeyDown(e);
        }
    }
