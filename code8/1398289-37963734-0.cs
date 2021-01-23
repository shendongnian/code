     public class SortColumn
    {
        public static string Property = "";
        public static bool MeaningSort = true;
        public static DependencyProperty AtSortingColumnCommandProperty = DependencyProperty.RegisterAttached("AtSortingColumnCommand",
            typeof(ICommand), typeof(SortColumn), new PropertyMetadata(OnAtSortingColumnCommandChanged));
        public static ICommand GetAtSortingColumnCommand(DependencyObject obj)
        {
            return (ICommand)obj.GetValue(AtSortingColumnCommandProperty);
        }
        public static void SetAtSortingColumnCommand(DependencyObject obj, ICommand value)
        {
            obj.SetValue(AtSortingColumnCommandProperty, value);
        }
        public static void OnAtSortingColumnCommandChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var myDataGrid = d as DataGrid;
            if (myDataGrid != null)
            {
                myDataGrid.Sorting -= HandleColumnSorting;
                myDataGrid.Sorting += HandleColumnSorting;
            }
        }
        static void HandleColumnSorting(object sender, DataGridSortingEventArgs e)
        {
            var myDataGridSorting = sender as DataGrid;
            string FiledName = e.Column.SortMemberPath;
            if (Property == null || (Property != FiledName && MeaningSort != false))
            {
                e.Column.SortDirection = ListSortDirection.Ascending;
                MeaningSort = false;
                var atEnd = GetAtSortingColumnCommand(myDataGridSorting);
                if (atEnd != null)
                {
                    atEnd.Execute(FiledName + " ASC");
                }
            }
            else
            {
                e.Column.SortDirection = ListSortDirection.Descending;
                MeaningSort = true;
                var atEnd = GetAtSortingColumnCommand(myDataGridSorting);
                if (atEnd != null)
                {
                    atEnd.Execute(FiledName + " DESC");
                }
            }
        }
    }
