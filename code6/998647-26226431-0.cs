		private void grdConvictions_CellEnter(object sender, DataGridViewCellEventArgs e)
		{
			int colIndex = e.ColumnIndex;
			int rowIndex = e.RowIndex;
			if (rowIndex < 0 || colIndex < 0)
			{
				return;
			}
		    DataGridView grd = (DataGridView)sender;
			if (grd[e.ColumnIndex, e.RowIndex].GetType().Name != "DataGridViewComboBoxCell")
			{
				((DataGridViewComboBoxCell)grd.CurrentCell).DisplayStyle = DataGridViewComboBoxDisplayStyle.DropDownButton;
			}
}
		private void grdConvictions_CellLeave(object sender, DataGridViewCellEventArgs e)
		{
			int colIndex = e.ColumnIndex;
			int rowIndex = e.RowIndex;
			if (rowIndex < 0 || colIndex < 0)
			{
				return;
			}
			DataGridView grd = (DataGridView)sender;
			if (grd[e.ColumnIndex, e.RowIndex].GetType().Name != "DataGridViewComboBoxCell")
			{
				((DataGridViewComboBoxCell)grd.CurrentCell).DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing;
			}
		}
