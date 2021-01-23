	public partial class ViewContainingDataGrid : UserControl
	{
		public ViewContainingDataGrid()
		{
			this.InitializeComponent();
		}
        private void datagrid_Sorting(object sender, DataGridSortingEventArgs e)
        {
            e.Handled = true;
            SmartSort(sender, e.Column);
        }
        private void SmartSort(object sender, DataGridColumn column)
        {
            ListSortDirection direction = (column.SortDirection != ListSortDirection.Ascending) ?
                                 ListSortDirection.Ascending : ListSortDirection.Descending;
            
            column.SortDirection = direction;
            var dg = sender as DataGrid;
            var lcv = (ListCollectionView)CollectionViewSource.GetDefaultView(dg.ItemsSource);
            lcv.CustomSort = new SmartSorter(direction);
        }
	}
    public class SmartSorter : IComparer
    {
        public ListSortDirection Direction { get; private set; }
        public SmartSorter(ListSortDirection direction)
        {
            Direction = direction;
        }
        public int Compare(object x, object y)
        {
            string valorx = x as string;
            string valory = y as string;
            int comparison = valorx.CompareTo(valory);
            if (Direction == ListSortDirection.Descending)
                comparison *= -1;
            // Override the sorting altogether when you find the special row value
            if (String.IsNullOrWhiteSpace(valorx))
                comparison = -1;
            else
            if (String.IsNullOrWhiteSpace(valory))
                comparison = 1;
            return comparison;
        }
    }
