                c.Open();
                string columns = "(";
                string values = "(";
                foreach (DataGridViewColumn column in rootDataView.Columns)
                {
                    if (virtualColumns.Contains(column.Name))
                    {
                    }
                    else
                    {
                        columns += column.Name + ",";
                        if (column.Name != "timeFrom")
                        {
                            values += "@" + column.Name + " ,";
                        } else {
                            //change in string
                            values += "GETDATE() ,";
                        }
                    }
                }
                columns = columns.Substring(0, columns.Length - 1) + ")";
                values = values.Substring(0, values.Length - 1) + ")";
                SqlCommand command = new SqlCommand("insert into " + tableName + " " + columns + " Values " + values, c);
                foreach (DataGridViewColumn column in rootDataView.Columns)
                {
                    if (virtualColumns.Contains(column.Name))
                    {
                    }
                    else
                    {
                        if (column.Name != "timeFrom")
                        {
                            command.Parameters.AddWithValue("@" + column.Name, editedRow.Cells[column.Name].Value);
                        }
                    }
                }
                command.ExecuteNonQuery();
