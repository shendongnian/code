    public static readonly DependencyProperty IsFiltersClearedProperty = DependencyProperty.Register("IsFiltersCleared", typeof(bool), typeof(XamDataGridClearFilters), new FrameworkPropertyMetadata(false, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, ClearFilters));
 
     public bool IsFiltersCleared
            {
                get { return (bool)GetValue(IsFiltersClearedProperty); }
                set { SetValue(IsFiltersClearedProperty, value); }
            }
        private static void ClearFilters(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (!(bool)e.NewValue)
            {
                return;
            }
            XamDataGridClearFilters gridExtender = (XamDataGridClearFilters)d;
            XamDataGrid dataGrid = (XamDataGrid)gridExtender.AssociatedObject;
            dataGrid.ClearCustomizations(CustomizationType.RecordFilters);
            gridExtender.IsFiltersCleared = false;
        }
    }
