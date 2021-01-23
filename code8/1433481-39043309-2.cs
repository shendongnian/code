        #region GetPosition
        // Modified from answer to: tablelayoutPanel get cell location from mouse over
        // By:  Aland Li Microsoft CSS
        // https://social.msdn.microsoft.com/Forums/windows/en-US/9bb6f42e-046d-42a0-8c83-febb1dcf98a7/tablelayoutpanel-get-cell-location-from-mouse-over?forum=winforms
    //The method to get the position of the cell under the mouse.
    private TableLayoutPanelCellPosition GetCellPosition(TableLayoutPanel panel, Point p)
    {
        //Cell position
        TableLayoutPanelCellPosition pos = new TableLayoutPanelCellPosition(0, 0);
        //Panel size.
        Size size = panel.Size;
        //average cell size.
        SizeF cellAutoSize = new SizeF(size.Width / panel.ColumnCount, size.Height / panel.RowCount);
        //Get the cell row.
        //y coordinate
        float y = 0;
        for (int i = 0; i < panel.RowCount; i++)
        {
            //Calculate the summary of the row heights.
            SizeType type = panel.RowStyles[i].SizeType;
            float height = panel.RowStyles[i].Height;
            switch (type)
            {
                case SizeType.Absolute:
                    y += height;
                    break;
                case SizeType.Percent:
                    y += height / 100 * size.Height;
                    break;
                case SizeType.AutoSize:
                    y += cellAutoSize.Height;
                    break;
            }
            //Check the mouse position to decide if the cell is in current row.
            if ((int)y > p.Y)
            {
                pos.Row = i;
                break;
            }
        }
        //Get the cell column.
        //x coordinate
        float x = 0;
        for (int i = 0; i < panel.ColumnCount; i++)
        {
            //Calculate the summary of the row widths.
            SizeType type = panel.ColumnStyles[i].SizeType;
            float width = panel.ColumnStyles[i].Width;
            switch (type)
            {
                case SizeType.Absolute:
                    x += width;
                    break;
                case SizeType.Percent:
                    x += width / 100 * size.Width;
                    break;
                case SizeType.AutoSize:
                    x += cellAutoSize.Width;
                    break;
            }
            //Check the mouse position to decide if the cell is in current column.
            if ((int)x > p.X)
            {
                pos.Column = i;
                break;
            }
        }
        //return the mouse position.
        return pos;
    }
    #endregion
