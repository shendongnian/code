        private void dataGridView1_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                int newRow;
                int newColumn;
                if (dataGridView1.CurrentCell.ColumnIndex == dataGridView1.ColumnCount-1)         // it's a last column, move to next row;
                {
                    newRow = dataGridView1.CurrentCell.RowIndex + 1;
                    newColumn = 0;
                    if (newRow == dataGridView1.RowCount)
                        return; // ADD new row or RETURN (depends of your purposes..)
                }
                else                // just change current column. row is same
                {
                    newRow = dataGridView1.CurrentCell.RowIndex;
                    newColumn = dataGridView1.CurrentCell.ColumnIndex + 1;
                }
                dataGridView1.CurrentCell = dataGridView1.Rows[newRow].Cells[newColumn];
            }
        }
