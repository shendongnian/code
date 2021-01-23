        if (rectangle.Contains(e.Location))
        {
            // *
            Point cell = new Point(column, row);
            if (!clickedCells.Contains(cell)) clickedCells.Add(cell);
            // **
            tableLayoutPanel1.Invalidate();
            return;
        }
