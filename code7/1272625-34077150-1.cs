            for (var columnIndex = 1; columnIndex < edgv.ColumnCount; columnIndex++)
            {
                for (var rowIndex = 1; rowIndex < edgv.RowCount; rowIndex++)
                {
                    var currentValue = edgv[columnIndex, rowIndex].Value as SomeClass;
                    if (currentValue == null) break; //Skipping the check for this column
                    if (currentValue.Attribute != null)
                    {
                        values.Add(currentValue);
                    }
                }
            }
