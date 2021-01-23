    public static class ListViewExtentions
    {
        public static readonly DependencyProperty SelectedItemsProperty = DependencyProperty.RegisterAttached(
            "SelectedItems", typeof (IList), typeof (ListViewExtentions), new PropertyMetadata(SelectedItems_PropertyChanged));
        public static void SetSelectedItems(DependencyObject element, IList value)
        {
            element.SetValue(SelectedItemsProperty, value);
        }
        public static IList GetSelectedItems(DependencyObject element)
        {
            return (IList)element.GetValue(SelectedItemsProperty);
        }
        private static void SelectedItems_PropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var listView = (ListView) d;
            SynchronizeCollections(listView.SelectedItems, (IList)e.NewValue);
            listView.SelectionChanged += (sender, args) =>
            {
                var listviewSelectedItems = ((ListView) sender).SelectedItems;
                var viewmodelCollection = GetSelectedItems((ListView) sender);
                SynchronizeCollections(listviewSelectedItems, viewmodelCollection);
            };
        }
        private static void SynchronizeCollections(IList source, IList target)
        {
            var oldItems = target.OfType<object>().Except(source.OfType<object>()).ToArray();
            var newItems = source.OfType<object>().Except(target.OfType<object>()).ToArray();
            foreach (var oldItem in oldItems) target.Remove(oldItem);
            foreach (var newItem in newItems) target.Add(newItem);
        }
    }
