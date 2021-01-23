    public class FilterDataGridViewColumnHeader : DataGridViewColumnHeaderCell
    {
        protected override void Paint(System.Drawing.Graphics graphics, System.Drawing.Rectangle clipBounds, System.Drawing.Rectangle cellBounds, int rowIndex, DataGridViewElementStates dataGridViewElementState, object value, object formattedValue, string errorText, DataGridViewCellStyle cellStyle, DataGridViewAdvancedBorderStyle advancedBorderStyle, DataGridViewPaintParts paintParts)
        {
            base.Paint(graphics, clipBounds, cellBounds, rowIndex, dataGridViewElementState, value, formattedValue, errorText, cellStyle, advancedBorderStyle, paintParts);
            ComboBoxRenderer.DrawDropDownButton(graphics, new System.Drawing.Rectangle(cellBounds.Right - 16, 4, 14, cellBounds.Height - 6), System.Windows.Forms.VisualStyles.ComboBoxState.Normal);
        }
    }
