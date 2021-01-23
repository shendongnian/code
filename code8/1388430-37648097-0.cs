    public class CustomHeaderCell : DataGridViewRowHeaderCell
    {
        protected override Size GetPreferredSize(Graphics graphics, DataGridViewCellStyle cellStyle, int rowIndex, Size constraintSize)
        {
            var size1 = base.GetPreferredSize(graphics, cellStyle, rowIndex, constraintSize);
            var value = string.Format("{0}", this.DataGridView.Rows[rowIndex].HeaderCell.FormattedValue);
            var size2 = TextRenderer.MeasureText(value, cellStyle.Font);
            var padding = cellStyle.Padding;
            return new Size(size2.Width + padding.Left+padding.Right, size1.Height);
        }
        protected override void Paint(Graphics graphics, Rectangle clipBounds, Rectangle cellBounds, int rowIndex, DataGridViewElementStates cellState, object value, object formattedValue, string errorText, DataGridViewCellStyle cellStyle, DataGridViewAdvancedBorderStyle advancedBorderStyle, DataGridViewPaintParts paintParts)
        {
            base.Paint(graphics, clipBounds, cellBounds, rowIndex, cellState, value, formattedValue, errorText, cellStyle, advancedBorderStyle, DataGridViewPaintParts.Background);
            base.PaintBorder(graphics, clipBounds, cellBounds, cellStyle, advancedBorderStyle);
            TextRenderer.DrawText(graphics, string.Format("{0}", formattedValue), cellStyle.Font, cellBounds, cellStyle.ForeColor);
        }
    }
