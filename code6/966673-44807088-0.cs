    public class GroupByGrid : DataGridView
        {
 
            protected override void OnCellFormatting(
               DataGridViewCellFormattingEventArgs args)
            {
                // Call home to base
                base.OnCellFormatting(args);
 
                // First row always displays
                if (args.RowIndex == 0)
                    return;
 
 
                if (IsRepeatedCellValue(args.RowIndex, args.ColumnIndex))
                {
                    args.Value = string.Empty;
                    args.FormattingApplied = true;
                }
            }
 
            private bool IsRepeatedCellValue(int rowIndex, int colIndex)
            {
                DataGridViewCell currCell =
                   Rows[rowIndex].Cells[colIndex];
                DataGridViewCell prevCell =
                   Rows[rowIndex - 1].Cells[colIndex];
 
                if ((currCell.Value == prevCell.Value) ||
                   (currCell.Value != null && prevCell.Value != null &&
                   currCell.Value.ToString() == prevCell.Value.ToString()))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
 
            protected override void OnCellPainting(
               DataGridViewCellPaintingEventArgs args)
            {
                base.OnCellPainting(args);
 
                args.AdvancedBorderStyle.Bottom =
                   DataGridViewAdvancedCellBorderStyle.None;
 
                // Ignore column and row headers and first row
                if (args.RowIndex < 1 || args.ColumnIndex < 0)
                    return;
 
                if (IsRepeatedCellValue(args.RowIndex, args.ColumnIndex))
                {
                    args.AdvancedBorderStyle.Top =
                       DataGridViewAdvancedCellBorderStyle.None;
                }
                else
                {
                    args.AdvancedBorderStyle.Top = AdvancedCellBorderStyle.Top;
                }
            }
        }
