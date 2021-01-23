    public class ComboBoxLoadingBehavior:Behavior<ComboBox>
    {
        private bool _unLoaded;
        protected override void OnAttached()
        {
            base.OnAttached();
            AssociatedObject.Loaded += AssociatedObjectOnLoaded;
            AssociatedObject.LayoutUpdated += AssociatedObjectOnLayoutUpdated;
            AssociatedObject.Unloaded += AssociatedObjectOnUnloaded;
        }
        private void AssociatedObjectOnUnloaded(object sender, RoutedEventArgs routedEventArgs)
        {
            _unLoaded = true;
            UnsubscribeAll();
        }
        private void UnsubscribeAll()
        {
            AssociatedObject.Loaded -= AssociatedObjectOnLoaded;
            AssociatedObject.LayoutUpdated -= AssociatedObjectOnLayoutUpdated;
            AssociatedObject.Unloaded -= AssociatedObjectOnUnloaded;
        }
        private void AssociatedObjectOnLayoutUpdated(object sender, EventArgs eventArgs)
        {
            UpdateSelectionState(sender);
        }
        private static void UpdateSelectionState(object sender)
        {
            var combo = sender as ComboBox;
            if (combo == null) return;
            var selectedItem = combo.SelectedItem as SubModel;
            if (selectedItem == null)
            {
                combo.SelectedIndex = 0;
            }
        }
        private void AssociatedObjectOnLoaded(object sender, RoutedEventArgs routedEventArgs)
        {
            _unLoaded = false;
            UpdateSelectionState(sender);
        }
        protected override void OnDetaching()
        {
            base.OnDetaching();
            if(_unLoaded) return;
            UnsubscribeAll();
        }
    }
