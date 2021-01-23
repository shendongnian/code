    public static class AttachedProperties
    {
        #region AttachedProperties.SelectedItems Attached Property
        public static IList GetSelectedItems(ListBox obj)
        {
            return (IList)obj.GetValue(SelectedItemsProperty);
        }
        public static void SetSelectedItems(ListBox obj, IList value)
        {
            obj.SetValue(SelectedItemsProperty, value);
        }
        public static readonly DependencyProperty 
            SelectedItemsProperty =
                DependencyProperty.RegisterAttached(
                    "SelectedItems", 
                    typeof(IList), 
                    typeof(AttachedProperties),
                    new PropertyMetadata(null, 
                        SelectedItems_PropertyChanged));
        private static void SelectedItems_PropertyChanged(
            DependencyObject d, 
            DependencyPropertyChangedEventArgs e)
        {
            var lb = d as ListBox;
            IList coll = e.NewValue as IList;
            //  If you want to go both ways and have changes to this 
            //  collection reflected back into the listbox, finish this.
            //  Of course, it'll quietly fail to do that if the consumer 
            //  gave you something that won't send change notifications. 
            if (coll is INotifyCollectionChanged)
            {
                (coll as INotifyCollectionChanged)
                    .CollectionChanged += (s, e3) =>
                {
                    //  TODO:
                    //  Update lb.SelectedItems
                };
            }
            if (coll.Count > 0)
            {
                //  TODO:
                //  If coll's not empty, update lb.SelectedItems
            }
            //  OK, now when lb.SelectedItems changes, reflect those changes
            //  back to the collection the viewmodel (or whoever) just gave us.
            lb.SelectionChanged += (s, e2) =>
            {
                if (null != e2.RemovedItems)
                    foreach (var item in e2.RemovedItems)
                        coll.Remove(item);
                if (null != e2.AddedItems)
                    foreach (var item in e2.AddedItems)
                        coll.Add(item);
            };
        }
        #endregion AttachedProperties.SelectedItems Attached Property
    }
