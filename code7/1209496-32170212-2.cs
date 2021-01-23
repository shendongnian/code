    private void dataGridView1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
    {
        //Draw only grid content cells not ColumnHeader cells nor RowHeader cells
        if (e.ColumnIndex > -1 & e.RowIndex > -1)
        {
            //Pen for left and top borders
            using (var backGroundPen = new Pen(e.CellStyle.BackColor, 1))
            //Pen for bottom and right borders
            using (var gridlinePen = new Pen(dataGridView1.GridColor, 1))
            //Pen for selected cell borders
            using (var selectedPen = new Pen(Color.Red, 1))
            {
                var topLeftPoint = new Point(e.CellBounds.Left, e.CellBounds.Top);
                var topRightPoint = new Point(e.CellBounds.Right - 1, e.CellBounds.Top);
                var bottomRightPoint = new Point(e.CellBounds.Right - 1, e.CellBounds.Bottom - 1);
                var bottomleftPoint = new Point(e.CellBounds.Left, e.CellBounds.Bottom - 1);
                //Draw selected cells here
                if (this.dataGridView1[e.ColumnIndex, e.RowIndex].Selected)
                {
                    //Paint all parts except borders.
                    e.Paint(e.ClipBounds, DataGridViewPaintParts.All & ~DataGridViewPaintParts.Border);
                    //Draw selected cells border here
                    e.Graphics.DrawRectangle(selectedPen, new Rectangle(e.CellBounds.Left, e.CellBounds.Top, e.CellBounds.Width - 1, e.CellBounds.Height - 1));
                    //Handled painting for this cell, Stop default rendering.
                    e.Handled = true;
                }
                //Draw non-selected cells here
                else
                {
                    //Paint all parts except borders.
                    e.Paint(e.ClipBounds, DataGridViewPaintParts.All & ~DataGridViewPaintParts.Border);
                    //Top border of first row cells should be in background color
                    if (e.RowIndex == 0)
                        e.Graphics.DrawLine(backGroundPen, topLeftPoint, topRightPoint);
                    //Left border of first column cells should be in background color
                    if (e.ColumnIndex == 0)
                        e.Graphics.DrawLine(backGroundPen, topLeftPoint, bottomleftPoint);
                    //Bottom border of last row cells should be in gridLine color
                    if (e.RowIndex == dataGridView1.RowCount - 1)
                        e.Graphics.DrawLine(gridlinePen, bottomRightPoint, bottomleftPoint);
                    else  //Bottom border of non-last row cells should be in background color
                        e.Graphics.DrawLine(backGroundPen, bottomRightPoint, bottomleftPoint);
                    //Right border of last column cells should be in gridLine color
                    if (e.ColumnIndex == dataGridView1.ColumnCount - 1)
                        e.Graphics.DrawLine(gridlinePen, bottomRightPoint, topRightPoint);
                    else //Right border of non-last column cells should be in background color
                        e.Graphics.DrawLine(backGroundPen, bottomRightPoint, topRightPoint);
                    //Top border of non-first row cells should be in gridLine color, and they should be drawn here after right border
                    if (e.RowIndex > 0)
                        e.Graphics.DrawLine(gridlinePen, topLeftPoint, topRightPoint);
                    //Left border of non-first column cells should be in gridLine color, and they should be drawn here after bottom border
                    if (e.ColumnIndex > 0)
                        e.Graphics.DrawLine(gridlinePen, topLeftPoint, bottomleftPoint);
                    //We handled painting for this cell, Stop default rendering.
                    e.Handled = true;
                }
            }
        }
    }
