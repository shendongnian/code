    private double getRowHeight(TableRow row)
        {
            double maxHeight = 0;
            foreach (TableCell cell in row.Cells)
            {
                Rect startRect = cell.ElementStart.GetCharacterRect(LogicalDirection.Forward);
                Rect endRect = cell.ElementEnd.GetNextInsertionPosition(LogicalDirection.Backward).GetCharacterRect(LogicalDirection.Forward);
                double Height = (endRect.Bottom - startRect.Top);
                maxHeight = maxHeight > Height ? maxHeight : Height;
            }
            return maxHeight;
        }
