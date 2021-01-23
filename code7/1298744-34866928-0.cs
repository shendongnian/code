		public int RowCount { get; set; }
		public int ColumnCount {get; set; }		
		public string StarCount { get; set; }
		public string StarRows { get; set; }
		public string StarColumns { get; set; }
		public List<Tuple<SomeClass, bool>> AllItems { get; set; } // second parameter indicates whether it's a header
		
		private void UpdateGridLayout()
		{
			this.AllItems = new List<Tuple<SomeClass, bool>>();
			this.ColumnCount = 5;
			this.RowCount = HahaList.Sum(x => 1 + (x.ItemList.Count() + this.ColumnCount - 1) / this.ColumnCount);
			int row = 0;
			this.StarColumns = String.Join(",", Enumerable.Range(0, this.ColumnCount).Select(i => i.ToString())); // all columns
			this.StarRows = null;
			foreach (var section in this.HahaList)
			{
				this.AllItems.Add(new Tuple<SomeClass, bool>(section, true));
				section.Row = row;
				section.Column = 0;
				section.ColumnSpan = this.ColumnCount;
				row++;
				if (StarRows != null)
					StarRows += ",";
				StarRows += row.ToString();
				int column = 0;				
				foreach (var item in section.ItemList)
				{
					this.AllItems.Add(new Tuple<SomeClass, bool>(item, false));
					item.Row = row;
					item.Column = column++;
					item.ColumnSpan = 1;
					if (column >= this.ColumnCount)
					{						
						column = 0;
						row++;
						if (StarRows != null)
							StarRows += ",";
						StarRows += row.ToString();
					}
				}
				row++;
			}
			return;
		}
