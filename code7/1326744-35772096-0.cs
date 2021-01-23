	public partial class TableView<CollectionType, ItemType> : Form
	{
		public TableView(CollectionType elements)
		{
			InitializeComponent();
			// custom:
			this.DataGridView.DataSource = elements;
			AdaptColumnsToColumnValueType();
			// necessary for custom DateTimePicker:
			this.DataGridView.CellBeginEdit += DataGridView_CellBeginEdit;
			this.DataGridView.CellEndEdit += DataGridView_CellEndEdit;
		}
		private void AdaptColumnsToColumnValueType()
		{
			for (int columnIndex = 0; columnIndex < this.DataGridView.Columns.Count; columnIndex++)
			{
				var column = (DataGridViewColumn)this.DataGridView.Columns[columnIndex];
				if (column.ValueType.IsEnum)
				{
					ReplaceColumnInDatagridView(
						oldColumn: column,
						newColumn: CreateComboBoxWithEnums(column));
				}
			}
		}
		private void ReplaceColumnInDatagridView(DataGridViewColumn oldColumn, DataGridViewColumn newColumn)
		{
			int columnIndex = oldColumn.Index;
			this.DataGridView.Columns.Remove(oldColumn);
			this.DataGridView.Columns.Insert(columnIndex, newColumn);
		}
		private DataGridViewComboBoxColumn CreateComboBoxWithEnums(DataGridViewColumn replacedEnumColumn)
		{
			var comboboxColumn = new DataGridViewComboBoxColumn();
			comboboxColumn.DataSource = Enum.GetValues(replacedEnumColumn.ValueType);
			comboboxColumn.DataPropertyName = replacedEnumColumn.DataPropertyName;
			comboboxColumn.Name = replacedEnumColumn.Name;
			return comboboxColumn;
		}
	}
