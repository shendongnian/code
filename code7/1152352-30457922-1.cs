        private void DataGrid_Sorting(object sender, DataGridSortingEventArgs e)
        {
            e.Handled = true;
            // Set the sort order on the column
            e.Column.SortDirection = (e.Column.SortDirection != ListSortDirection.Ascending) 
                ? ListSortDirection.Ascending : ListSortDirection.Descending;
            // Sort data based on predefined order of group headers and currently sorting column.
            GroupedList.CustomSort = new CustomSorter(e.Column.SortMemberPath, e.Column.SortDirection);
        }
