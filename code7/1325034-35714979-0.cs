      private void SaveToTextFIle()
        {
            //get all distinct categories
            DataView view = new DataView((DataTable)dataGridView1.DataSource);
            DataTable distinctValues = view.ToTable(true, "CategoryID");
            
            //save each category
            foreach (DataRow categoryRow in distinctValues.Rows)
            {
                var sb = new StringBuilder();
                
                //if you want headers
                var headers = dataGridView1.Columns.Cast<DataGridViewColumn>();
                sb.AppendLine(string.Join(",", headers.Select(column => "\"" + column.HeaderText + "\"").ToArray()));
                
                //form actual data available for this category
                foreach (DataGridViewRow row in dataGridView1.Rows.Cast<DataGridViewRow>().Where(r => r.Cells["CategoryID"].Value.ToString() == categoryRow["CategoryID"].ToString()))
                {
                    var cells = row.Cells.Cast<DataGridViewCell>();
                    sb.AppendLine(string.Join(",", cells.Select(cell => "\"" + cell.Value + "\"").ToArray()));
                }
                //write to file
                File.WriteAllText(@"D:\" + categoryRow["CategoryID"] + ".txt", sb.ToString());
             }
        }
