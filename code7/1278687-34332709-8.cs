    public partial class MainWindow : Window
    {
        private readonly DataTable _dataTable;
        public MainWindow()
        {
            InitializeComponent();
            this.MyDataGrid.CellEditEnding += MyDataGrid_CellEditEnding;
            _dataTable = new DataTable();
            _dataTable.Columns.Add(new DataColumn());
            _dataTable.Columns.Add(new DataColumn());
            DataRow existingRow = _dataTable.NewRow();
            _dataTable.Rows.Add(existingRow);
            
            this.MyDataGrid.ItemsSource = _dataTable.DefaultView;
            
        }
        void MyDataGrid_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            var dataRowView = (e.Row.Item as DataRowView);
            var columnIndex = e.Column.DisplayIndex;
            var rowIndex = e.Row.GetIndex();
            var dv = _dataTable.DefaultView;
            var nextColumnIndex = columnIndex + 1;
            if (dv.Table.Columns.Count <= nextColumnIndex || dv.Table.Rows.Count <= rowIndex) return;
            dv.Table.Rows[rowIndex][nextColumnIndex] = "a string that should be displayed immediatly";
        }
    }
