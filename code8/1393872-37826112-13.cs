    protected void GridView1_PreRender(object sender, EventArgs e)
    {
        List<int> sortedColIndexes = null;
        if (sortRowIndex >= 0)
        {
            // Gather the cell data on the sorted row...
            List<KeyValuePair<string, int>> cellsToSort = new List<KeyValuePair<string, int>>();
            sortedColIndexes = new List<int>();
            GridViewRow sortedRow = GridView1.Rows[sortRowIndex];
            for (int i = fixedColumnCount; i < sortedRow.Cells.Count; i++)
            {
                TableCell cell = sortedRow.Cells[i];
                cellsToSort.Add(new KeyValuePair<string, int>(cell.Text, i));
            }
            // ... and sort the cell indexes according to the cell content
            sortedColIndexes = cellsToSort.OrderBy(x => x.Key).Select(x => x.Value).ToList();
        }
        RearrangeRowCells(GridView1.HeaderRow, sortedColIndexes);
        foreach (GridViewRow row in GridView1.Rows)
        {
            RearrangeRowCells(row, sortedColIndexes);
        
            // The code below is taken from the other post
            // It merges the cells with the same content
            for (int i = 0; i < row.Cells.Count - 1; i++)
            {
                TableCell cell = row.Cells[i];
                if (cell.Visible)
                {
                    int colSpanValue = 1;
                    for (int j = i + 1; j < row.Cells.Count; j++)
                    {
                        TableCell otherCell = row.Cells[j];
                        if (otherCell.Text == cell.Text)
                        {
                            colSpanValue++;
                            otherCell.Visible = false;
                        }
                        else
                        {
                            break;
                        }
                    }
                    if (colSpanValue > 1)
                    {
                        cell.ColumnSpan = colSpanValue;
                        cell.BackColor = System.Drawing.Color.Beige;
                        cell.HorizontalAlign = HorizontalAlign.Center;
                    }
                }
            }
        }
    }
    // Utility function which performs the cell permutations on a given row
    private void RearrangeRowCells(GridViewRow row, List<int> sortedColIndexes)
    {
        if (sortedColIndexes != null)
        {
            List<TableCell> sortedCells = new List<TableCell>();
            foreach (int cellIndex in sortedColIndexes)
            {
                sortedCells.Add(row.Cells[cellIndex]);
            }
            for (int i = fixedColumnCount; i < sortedCells.Count - 1; i++)
            {
                row.Cells.Remove(sortedCells[i]);
                row.Cells.AddAt(i + fixedColumnCount, sortedCells[i]);
            }
        }
    }
