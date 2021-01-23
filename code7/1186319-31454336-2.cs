	public class DataGridViewCustomPaintComboBox : DataGridViewComboBoxColumn
	{
		public DataGridViewCustomPaintComboBox()
		{
			base.New();
			CellTemplate = new DataGridViewCustomPaintComboBoxCell();
		}
	}
	public class DataGridViewCustomPaintComboBoxCell : DataGridViewComboBoxCell
	{
		protected override void Paint(Graphics graphics, Rectangle clipBounds, Rectangle cellBounds, int rowIndex, DataGridViewElementStates elementState, object value, object formattedValue, string errorText, DataGridViewCellStyle cellStyle, DataGridViewAdvancedBorderStyle advancedBorderStyle, DataGridViewPaintParts paintParts)
		{
            // modify received arguments here
			base.Paint(...); // paint default parts (see paintParts argument)
            // add any custom painting here
		}
	}
