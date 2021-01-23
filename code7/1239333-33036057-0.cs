     public class IndexItemHelper
    {
        #region ListIndexer
        /// <summary>
        /// ListIndexer Attached Dependency Property
        /// </summary>
        public static readonly DependencyProperty ListIndexerProperty =
            DependencyProperty.RegisterAttached("ListIndexer", typeof(List<ListItem>), typeof(IndexItemHelper),
                new FrameworkPropertyMetadata((List<ListItem>)null,
                    new PropertyChangedCallback(OnListIndexerChanged)));
        /// <summary>
        /// Gets the ListIndexer property. This dependency property 
        /// indicates ....
        /// </summary>
        public static List<ListItem> GetListIndexer(DependencyObject d)
        {
            return (List<ListItem>)d.GetValue(ListIndexerProperty);
        }
        /// <summary>
        /// Sets the ListIndexer property. This dependency property 
        /// indicates ....
        /// </summary>
        public static void SetListIndexer(DependencyObject d, List<ListItem> value)
        {
            d.SetValue(ListIndexerProperty, value);
        }
        /// <summary>
        /// Handles changes to the ListIndexer property.
        /// </summary>
        private static void OnListIndexerChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            List<ListItem> oldListIndexer = (List<ListItem>)e.OldValue;
            List<ListItem> newListIndexer = (List<ListItem>)d.GetValue(ListIndexerProperty);
            UpdateDependencyObject(d);
        }
        #endregion
        #region ItemIndexOf
        /// <summary>
        /// ItemIndexOf Attached Dependency Property
        /// </summary>
        public static readonly DependencyProperty ItemIndexOfProperty =
            DependencyProperty.RegisterAttached("ItemIndexOf", typeof(object), typeof(IndexItemHelper),
                new FrameworkPropertyMetadata((object)null,
                    new PropertyChangedCallback(OnItemIndexOfChanged)));
        /// <summary>
        /// Gets the ItemIndexOf property. This dependency property 
        /// indicates ....
        /// </summary>
        public static object GetItemIndexOf(DependencyObject d)
        {
            return (object)d.GetValue(ItemIndexOfProperty);
        }
        /// <summary>
        /// Sets the ItemIndexOf property. This dependency property 
        /// indicates ....
        /// </summary>
        public static void SetItemIndexOf(DependencyObject d, object value)
        {
            d.SetValue(ItemIndexOfProperty, value);
        }
        /// <summary>
        /// Handles changes to the ItemIndexOf property.
        /// </summary>
        private static void OnItemIndexOfChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            object oldItemIndexOf = (object)e.OldValue;
            object newItemIndexOf = (object)d.GetValue(ItemIndexOfProperty);
            UpdateDependencyObject(d);
        }
        #endregion
        public static void UpdateDependencyObject(DependencyObject d)
        {
            var itemToGetIndexOf = GetItemIndexOf(d) as ListItem;
            var listToGetIndexFrom = GetListIndexer(d);
            if (itemToGetIndexOf == null || (listToGetIndexFrom == null || !listToGetIndexFrom.Any())) return;
            if (listToGetIndexFrom.IndexOf(itemToGetIndexOf) == (listToGetIndexFrom.Count - 1))
            {
                //this is the last line item
                var line = d as Line;
                if(line != null) line.Visibility = Visibility.Collapsed;
            }
            else
            {
                var line = d as Line;
                if (line != null) line.Visibility = Visibility.Visible;
            }
        }
    }
