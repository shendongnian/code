	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}
		// Hold the link texts, in a dictinary
		// keyed by ID (= unique key in DataTable1), to be bound to each row.
		private SortedDictionary<string, string> _linkTexts
			= new SortedDictionary<string, string>();
		private void Form1_Load(object sender, EventArgs e)
		{
			// Bound data sample
			this.dataSet1.DataTable1.AddDataTable1Row("1", "Comment1");
			this.dataSet1.DataTable1.AddDataTable1Row("2", "Comment2");
			this.dataSet1.DataTable1.AddDataTable1Row("3", "Comment3");
			// Unbound data sample
			this._linkTexts.Add("1", "linkA");
			this._linkTexts.Add("2", "linkC");
			this._linkTexts.Add("3", "linkB");
		}
		// Handles ColumnHeaderMouseClick to do custom sort.
		private void dataTable1DataGridView_ColumnHeaderMouseClick(
			object sender, DataGridViewCellMouseEventArgs e)
		{
			// When the unbound column header is clicked,
			if (e.ColumnIndex == this.linkColumn.Index)
			{
				// Create a new DataView sorted by the link text
				// with toggling the sort order.
				DataView newView;
				switch (this.linkColumn.HeaderCell.SortGlyphDirection)
				{
					case SortOrder.None:
					case SortOrder.Descending:
						this.linkColumn.HeaderCell.SortGlyphDirection
                            = SortOrder.Ascending;
						newView = this.dataSet1.DataTable1
							.OrderBy(row => this._linkTexts[row.ID])
                            .AsDataView();
						break;
					default:
						this.linkColumn.HeaderCell.SortGlyphDirection
                            = SortOrder.Descending;
						newView = this.dataSet1.DataTable1
							.OrderByDescending(row => this._linkTexts[row.ID])
                            .AsDataView();
						break;
				}
				// Set it as DataSource.
				this.dataTable1BindingSource.DataSource = newView;
				// Clear sort glyphs on the other column headers.
				foreach (DataGridViewColumn col
                         in this.dataTable1DataGridView.Columns)
				{
					if (col != this.linkColumn)
						col.HeaderCell.SortGlyphDirection = SortOrder.None;
				}
			}
			// The bound column header is clicked,
			else
			{
				// Sorting has done automatically.
				// Reset the sort glyph on the unbound column.
				this.linkColumn.HeaderCell.SortGlyphDirection = SortOrder.None;
			}
		}
		// Handles CellValueNeeded to show cell values in virtual mode.
		private void dataTable1DataGridView_CellValueNeeded(
			object sender, DataGridViewCellValueEventArgs e)
		{
			// Extract the bound row from the current data view.
			DataSet1.DataTable1Row row
				= (this.dataTable1BindingSource[e.RowIndex] as DataRowView)
				  .Row as DataSet1.DataTable1Row;
			// For the unbound column,
			if (e.ColumnIndex == this.linkColumn.Index)
			{
				if (row.IsIDNull())
					e.Value = DBNull.Value;
				else
					// get the value from the dictionary.
					e.Value = this._linkTexts[row.ID];
			}
			// For the bound columns,
			else
			{
				// get the value from the data source.
				string propName = this.dataTable1DataGridView
                                  .Columns[e.ColumnIndex].DataPropertyName;
				e.Value = row[propName];
			}
		}
	}
