    public class MyDataGridView : DataGridView
    {
        public new DataGridViewCell this[int col, int invertRow]
        {
            get { return this.Rows[this.RowCount - invertRow].Cells[col]; }
            set { this.Rows[this.RowCount - invertRow].Cells[col] = value; }
        }
    }
