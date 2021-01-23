    public partial class Form1 : Form
        {
            string value = "";
            public MainForm()
            {
                InitializeComponent();
            }
            
            private void textBox1_KeyDown(object sender, KeyEventArgs e)
            {
                if (dataGridView1.Visible == true)
                {
                    if (e.KeyCode.Equals(Keys.Up))
                    {
                        selectUpRow();
                    }
                    if (e.KeyCode.Equals(Keys.Down))
                    {
                        selectDownRow();
                    }
                    if (e.KeyCode.Equals(Keys.Enter))
                    {
                        selectCellValue();
                    }
                    e.Handled = true;
                }
            }
    
            private void selectUpRow()
            {
                DataGridView dgv = dataGridView1;
                int totalRows = dgv.Rows.Count;
                int rowIndex = dgv.SelectedCells[0].OwningRow.Index;
                if (rowIndex == 0)
                    return;
                int colIndex = dgv.SelectedCells[0].OwningColumn.Index;
                DataGridViewRow selectedRow = dgv.Rows[rowIndex];
                dgv.ClearSelection();
                dgv.Rows[rowIndex - 1].Cells[colIndex].Selected = true;
            }
    
            private void selectDownRow()
            {
                DataGridView dgv = dataGridView1;
                int totalRows = dgv.Rows.Count;
                int rowIndex = dgv.SelectedCells[0].OwningRow.Index;
                if (rowIndex == totalRows - 1)
                    return;
                int colIndex = dgv.SelectedCells[0].OwningColumn.Index;
                DataGridViewRow selectedRow = dgv.Rows[rowIndex];
                dgv.ClearSelection();
                dgv.Rows[rowIndex + 1].Cells[colIndex].Selected = true;
            }
    
            private void selectCellValue()
            {
                int rowIndex = dataGridView1.SelectedCells[0].OwningRow.Index;
                value = dataGridView1.Rows[rowIndex].Cells[0].Value.ToString();
            }
    
        }
