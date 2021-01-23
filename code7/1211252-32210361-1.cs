        /// <summary>
        /// Gets the Excel column name based on a supplied index number.
        /// </summary>
        /// <returns>1 = A, 2 = B... 27 = AA, etc.</returns>
        private string getColumnName(int columnIndex)
        {
            int dividend = columnIndex;
            string columnName = String.Empty;
            int modifier;
            while (dividend > 0)
            {
                modifier = (dividend - 1) % 26;
                columnName =
                    Convert.ToChar(65 + modifier).ToString() + columnName;
                dividend = (int)((dividend - modifier) / 26);
            }
            return columnName;
        }
        private Cell createTextCell(
            int columnIndex,
            int rowIndex,
            object cellValue)
        {
            Cell cell = new Cell();
            cell.DataType = CellValues.InlineString;
            cell.CellReference = getColumnName(columnIndex) + rowIndex;
            InlineString inlineString = new InlineString();
            Text t = new Text();
            t.Text = cellValue.ToString();
            inlineString.AppendChild(t);
            cell.AppendChild(inlineString);
            return cell;
        }
        private Row createContentRow(
            DataRow dataRow,
            int rowIndex)
        {
            Row row = new Row
            {
                RowIndex = (UInt32)rowIndex
            };
            for (int i = 0; i < dataRow.Table.Columns.Count; i++)
            {
                Cell dataCell = createTextCell(i + 1, rowIndex, dataRow[i]);
                row.AppendChild(dataCell);
            }
            return row;
        }
        #endregion
