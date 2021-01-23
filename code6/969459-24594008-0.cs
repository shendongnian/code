    private void DrawCrossingCells()
    {
        for (int row = 0; row < 3; row++)
        {
            List<Cell> rowCells = new List<Cell>();
            for (int col = 0; col < 4; col++)
            {
                Cell cell = new Cell(row, col);
                g.DrawRectangle(new Pen(Color.Blue), x, y, Cell.Width, Cell.Height);
                cell.Position = new Point(x, y);
                cell.Id = (col.ToString() + row.ToString()).ToString();
                x += 220;
                cell.Click += cell_Click;
                rowCells.Add(cell);
            }
            cells.Add(rowCells);
            x = 0;
            y += 220;
            }
        }
    private void Form1_MouseDown(object sender, MouseEventArgs e)
    {
        int row = e.Location.Y / 220; //divide by the Y size
        int column = e.Location.X / 220; //divide by the X size
        cells[row][column].OnClick(e.Location);
        label1.Text = e.Location.ToString();
    }
