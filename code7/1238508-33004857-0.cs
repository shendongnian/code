    void ShowTableInDataGrid(System.Data.Entity.Core.Metadata.Edm.EntityType myEntityType) {
			var tableName = myEntityType.GetType();
			var result = _context.Database.
						 SqlQuery<myEntityType.GetType()> ("SELECT * FROM dbo." + tableName).ToList();
			DataGridMain.ItemsSource = result;
		}
