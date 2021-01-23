    var selectedTable = new DataTable();
            if (tableEntities.Any())
            {
                var colunms = table.Properties;
                foreach (var colunm in colunms)
                {
                    selectedTable.Columns.Add(colunm.Key);
                }
                foreach (var entity in tableEntities)
                {
                    var row = selectedTable.NewRow();
                    foreach (var property in entity.Properties)
                    {
                        row[property.Key] = property.Value.GetStringValue();
                    }
                    selectedTable.Rows.Add(row);
                }
