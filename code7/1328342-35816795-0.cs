    private void tableLayoutPanel1_MouseClick(object sender, MouseEventArgs e)
    {
        var asp = tableLayoutPanel1.AutoScrollPosition;  // <<===
        row = 0;
        int verticalOffset = asp.Y;                      // <<===
        foreach (int h in tableLayoutPanel1.GetRowHeights())
        {
            column = 0;
            int horizontalOffset = asp.X;                // <<===
            foreach (int w in tableLayoutPanel1.GetColumnWidths())
            {
                Rectangle rectangle = new Rectangle(horizontalOffset, verticalOffset, w, h);
                if (rectangle.Contains(e.Location))
                {
                    if (column == 1) return;
                    Point cell = new Point(column, row);
                    if (!clickedCells.Contains(cell))
                    {    clickedCells.Add(cell);       }
                    else
                    {    clickedCells.Remove(cell);    }
                    tableLayoutPanel1.Invalidate();
                    MessageBox.Show(String.Format("row {0}, column {1} was clicked", 
                                    row, column));
                    return;
                }
                horizontalOffset += w;
                column++;
            }
            verticalOffset += h;
            row++;
        }
    }
