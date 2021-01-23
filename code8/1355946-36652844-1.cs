    protected void GridView1_DataBound(object sender, EventArgs e)
    {
        for (int currentRowIndex = 0; currentRowIndex < GridView1.Rows.Count; currentRowIndex++)
        {
            GridViewRow currentRow = GridView1.Rows[currentRowIndex];
            CombineColumnCells(currentRow, 0, "ClientCompany");
            CombineColumnCells(currentRow, 1, "Position");
        }
    }
    
    private void CombineColumnCells(GridViewRow currentRow, int colIndex, string fieldName)
    {
        TableCell currentCell = currentRow.Cells[colIndex];
    
        if (currentCell.Visible)
        {
            Object currentValue = GridView1.DataKeys[currentRow.RowIndex].Values[fieldName];
    
            for (int nextRowIndex = currentRow.RowIndex + 1; nextRowIndex < GridView1.Rows.Count; nextRowIndex++)
            {
                Object nextValue = GridView1.DataKeys[nextRowIndex].Values[fieldName];
    
                if (nextValue.ToString() == currentValue.ToString())
                {
                    GridViewRow nextRow = GridView1.Rows[nextRowIndex];
                    TableCell nextCell = nextRow.Cells[colIndex];
                    currentCell.RowSpan = Math.Max(1, currentCell.RowSpan) + 1;
                    nextCell.Visible = false;
                }
                else
                {
                    break;
                }
            }
        }
    }
