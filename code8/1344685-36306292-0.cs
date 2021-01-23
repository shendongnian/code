    /// <summary>
    /// Allows a grid to be sorted based upon the converted value.
    /// </summary>
    public static class GridEnumSortingBehavior
    {
        #region Properties
        public static readonly DependencyProperty UseBindingToSortProperty =
           DependencyProperty.RegisterAttached("UseBindingToSort", typeof(bool), typeof(GridEnumSortingBehavior),
                                               new PropertyMetadata(UseBindingToSortPropertyChanged));
        #endregion
        public static void SetUseBindingToSort(DependencyObject element, bool value)
        {
            element.SetValue(UseBindingToSortProperty, value);
        }
        #region Private events
        private static void UseBindingToSortPropertyChanged(DependencyObject element, DependencyPropertyChangedEventArgs e)
        {
            var grid = element as DataGrid;
            if (grid == null)
            {
                return;
            }
            var canEnumSort = (bool)e.NewValue;
            if (canEnumSort)
            {
                grid.Sorting += GridSorting;
            }
            else
            {
                grid.Sorting -= GridSorting;
            }
        }
        private static void GridSorting(object sender, DataGridSortingEventArgs e)
        {
            var boundColumn = e.Column as DataGridBoundColumn;
            if (boundColumn == null)
            {
                return;
            }
            // Fetch the converter,binding prop path name, if any
            IValueConverter converter = null;
            string bindingPropertyPath = null;
            if (boundColumn.Binding == null)
            {
                return;
            }
            var binding = boundColumn.Binding as Binding;
            if (binding == null || binding.Converter == null)
            {
                return;
            }
            converter = binding.Converter;
            bindingPropertyPath = binding.Path.Path;
            if (converter == null || bindingPropertyPath == null)
            {
                return;
            }
            // Fetch the collection
            var dataGrid = (DataGrid)sender;
            var lcv = (ListCollectionView)CollectionViewSource.GetDefaultView(dataGrid.ItemsSource);
            if (lcv == null || lcv.ItemProperties == null)
            {
                return;
            }
            // Fetch the property bound to the current column (being sorted)
            var bindingProperty = lcv.ItemProperties.FirstOrDefault(prop => prop.Name == bindingPropertyPath);
            if (bindingProperty == null)
            {
                return;
            }
            // Apply custom sort only for enums types
            var bindingPropertyType = bindingProperty.PropertyType;
            if (!bindingPropertyType.IsEnum)
            {
                return;
            }
            // Apply a custom sort by using a custom comparer for enums
            e.Handled = true;
            ListSortDirection directionToSort = boundColumn.SortDirection != ListSortDirection.Ascending
                                                     ? ListSortDirection.Ascending
                                                     : ListSortDirection.Descending;
            boundColumn.SortDirection = directionToSort;
            lcv.CustomSort = new ConvertedEnumComparer(converter, directionToSort, bindingPropertyType, bindingPropertyPath);
        }
        #endregion
    }
