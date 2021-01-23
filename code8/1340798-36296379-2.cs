    public class MyDataGrid : DataGrid {
        static MyDataGrid() {
            ItemsSourceProperty.OverrideMetadata(typeof(MyDataGrid), new FrameworkPropertyMetadata(null, OnCoerceItemsSourceProperty));
        }
        private static object OnCoerceItemsSourceProperty(DependencyObject d, object baseValue) {
            // do nothing here - we just want to override parent behaviour.
            // The _only_ thing DataGrid does here is clearing sort descriptors
            return baseValue;
        }
        protected override void OnItemsSourceChanged(IEnumerable oldValue, IEnumerable newValue) {
            SortDescription[] sorts = null;
            if (newValue == null) {
                // preserve sort descriptors when setting ItemsSource to null
                sorts = Items.SortDescriptions.ToArray();
            }
            // they will now be cleared here
            base.OnItemsSourceChanged(oldValue, newValue);            
            if (sorts != null) {
                // restore them back
                foreach (var sort in sorts) {
                    Items.SortDescriptions.Add(sort);
                }
            }
        }
    }
