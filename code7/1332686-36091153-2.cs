    private void paste2_Click(Object sender, EventArgs e)
        {
            char[] rowSplitter = { '\r', '\n' };
            char[] columnSplitter = { '\t' };
            // Get the text from clipboard
            IDataObject dataInClipboard = Clipboard.GetDataObject();
            string stringInClipboard = (string)dataInClipboard.GetData(DataFormats.Text);
            // Split it into lines
            string[] rowsInClipboard = stringInClipboard.Split(rowSplitter, StringSplitOptions.RemoveEmptyEntries);
            // Get the row and column of selected cell in grid
            int r = dataGridView1.SelectedCells[0].RowIndex;
            int c = dataGridView1.SelectedCells[0].ColumnIndex;
            // Add rows into grid to fit clipboard lines
            if (dataGridView1.Rows.Count < (r + rowsInClipboard.Length))
            {
                dataGridView1.Rows.Add(r + rowsInClipboard.Length - dataGridView1.Rows.Count);
            }
            // Loop through the lines, split them into cells and place the values in the corresponding cell.
            for (int iRow = 0; iRow < rowsInClipboard.Length; iRow++)
            {
                // Split row into cell values
                string[] valuesInRow = rowsInClipboard[iRow].Split(columnSplitter);
                // Cycle through cell values
                for (int iCol = 0; iCol < valuesInRow.Length; iCol++)
                {
                    // Assign cell value, only if it within columns of the grid
                    if (dataGridView1.ColumnCount - 1 >= c + iCol)
                    {
                        DataGridViewCell cell = dataGridView1.Rows[r + iRow].Cells[c + iCol];
                        if (!cell.ReadOnly)
                        {
                            cell.Value = valuesInRow[iCol+1];
                        }
                    }
                }
            }
        }
