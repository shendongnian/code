            foreach (DataGridViewRow row in targetTable.Rows)
            {
                if (!row.Cells[6].Value.Equals(null) && !row.Cells[6].Value.Equals(""))
                {
                    row.Cells[6].Value = int.Parse(row.Cells[6].Value.ToString());
                }
                else
                {
                    row.Cells[6].Value = row.Index + 1;
                }
            }
