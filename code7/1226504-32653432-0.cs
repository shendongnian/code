    public partial class RadExtendedGridViewController : RadGridView
    {
        public RadExtendedGridViewController()
        {
            InitializeComponent();
            base.MouseDown += RadExtendedGridViewController_MouseDown;
        }
        private void RadExtendedGridViewController_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                var element = this.ElementTree.GetElementAtPoint(e.Location);
                GridDataCellElement cell = element as GridDataCellElement;
                if (cell?.RowElement is GridDataRowElement)
                {
                    Rows[cell.RowIndex].IsSelected = true;
                }
            }
        }
    }
