    public class MyDataGridView : DataGridView
    {
        public new DataGridViewCell this[int col, int row]
        {
            get { return this.Rows[row].Cells[col]; }
            set { this.Rows[row].Cells[col] = value; }
        }
    }
