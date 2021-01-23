	public class DataGridViewImageComboBox : DataGridViewComboBoxColumn
	{
		public DataGridViewImageComboBox()
		{
			base.New();
			CellTemplate = new DataGridViewImageComboBoxCell();
		}
	}
	public class DataGridViewImageComboBoxCell : DataGridViewComboBoxCell
	{
		protected override void Paint(Graphics graphics, Rectangle clipBounds, Rectangle cellBounds, int rowIndex, DataGridViewElementStates elementState, object value, object formattedValue, string errorText, DataGridViewCellStyle cellStyle, DataGridViewAdvancedBorderStyle advancedBorderStyle,
		DataGridViewPaintParts paintParts)
		{
			base.Paint(...); // only in need of orginal painting
            // custom painting here
		}
	}
