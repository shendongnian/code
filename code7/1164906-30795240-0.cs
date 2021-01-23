    public partial class CustomGridControl : Grid
    {
        public DataTable DataTableSource
        {
            get
            {
                return (DataTable)GetValue(GridSource);
            }
            set
            {
                SetValue(GridSource, value);
            }
        }
        public static readonly DependencyProperty GridSource = DependencyProperty.Register("DataTableSource", typeof(DataTable), typeof(CustomGridControl), new PropertyMetadata(null));
    }
