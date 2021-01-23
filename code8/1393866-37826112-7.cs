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
