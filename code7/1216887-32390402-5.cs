		private int _NumColumns;
		public int NumColumns
		{
			get { return this._NumColumns; }
			set { this._NumColumns = value; RaisePropertyChanged(() => this.NumColumns); }
		}
		private int _NumRows;
		public int NumRows
		{
			get { return this._NumRows; }
			set { this._NumRows = value; RaisePropertyChanged(() => this.NumRows); }
		}
		private object[] _GridData;
		public object[] GridData
		{
			get { return this._GridData; }
			set { this._GridData = value; RaisePropertyChanged(() => this.GridData); }
		}
		private string[] Types = new string[] { "Type1", "Type2", "Type3" };
		private string[] Categories = new string[] { "Cat1", "Cat2", "Cat3" };
		private void UpdateGridData()
		{
			this.NumColumns = this.Categories.Length + 1;
			this.NumRows = this.Types.Length + 1;
			this.GridData = new object[(this.Categories.Length + 1) * (this.Types.Length + 1)];
			// set category and type headers
			for (int i=0; i<this.Categories.Length; i++)
				this.GridData[i + 1] = new CustomGridHeader { Column = i + 1, Row = 0, Header = this.Categories[i] };
			for (int i=0; i<this.Types.Length; i++)
				this.GridData[(i + 1) * this.NumColumns] = new CustomGridHeader { Column = 0, Row = i + 1, Header = this.Types[i] };
			// fill the cells
			for (int i = 0; i < this.Categories.Length; i++)
				for (int j = 0; j < this.Types.Length; j++)
					this.GridData[(i + 1) * this.NumColumns + j + 1] = new CustomGridCell {Column = i+1, Row = j+1, Content = String.Format("{0}/{1}", i, j)};
		}
