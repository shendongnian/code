        public string DataGridToCSV(string delimiter = ";")
        {
            var sb = new StringBuilder();
            var headers = myDataGridView.Columns.Cast<DataGridViewColumn>();
            sb.AppendLine(string.Join(delimiter, headers.Select(column => "\"" + column.HeaderText + "\"").ToArray()));
            foreach (DataGridViewRow row in myDataGridView.Rows)
            {
                var cells = row.Cells.Cast<DataGridViewCell>();
                sb.AppendLine(string.Join(delimiter, cells.Select(cell => "\"" + cell.Value + "\"").ToArray()));
            }
            return sb.ToString();
        }
