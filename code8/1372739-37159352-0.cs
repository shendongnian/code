    private void MergeCells()
    { 
        HierarchyItem rowItem1 = grid.RowsHierarchy.Items[0];
        HierarchyItem columnItem1 = grid.ColumnsHierarchy.Items[0];
    
        // create a custom cell style.
        GridCellStyle style = new GridCellStyle();
        style.FillStyle = new FillStyleSolid(Color.FromArgb(255, 0, 175, 240));
        style.Font = new Font(this.Font.FontFamily, 11.0f, FontStyle.Bold);
        style.TextColor = Color.White;
        GridCellStyle orangestyle = new GridCellStyle();
        orangestyle.FillStyle = new FillStyleSolid(Color.FromArgb(255, 254, 122, 1));
        orangestyle.Font = new Font(this.Font.FontFamily, 10.0f, FontStyle.Bold);
        orangestyle.TextColor = Color.White;
        grid.CellsArea.SetCellTextAlignment
        (rowItem1, columnItem1, ContentAlignment.MiddleCenter);
        // set the cell span to 1 row and 5 columns.
        grid.CellsArea.SetCellSpan(rowItem1, columnItem1, 1, 5);
        // set the merged cell value and style.
        grid.CellsArea.SetCellDrawStyle(rowItem1, columnItem1, style);
        // set the cell span to 1 row and 2 columns.
        grid.CellsArea.SetCellSpan(grid.RowsHierarchy.Items[1], columnItem1, 1, 3);
        grid.CellsArea.SetCellDrawStyle
        (grid.RowsHierarchy.Items[1], columnItem1, orangestyle);
    
        // set the merged cell value.
    
        // set the cell span to 1 row and 2 columns.
        grid.CellsArea.SetCellSpan
        (grid.RowsHierarchy.Items[1], this.grid.ColumnsHierarchy.Items[3], 1, 2);
    
        // set the merged cell value.
        grid.CellsArea.SetCellDrawStyle
        (grid.RowsHierarchy.Items[1], this.grid.ColumnsHierarchy.Items[3], orangestyle);
    }
