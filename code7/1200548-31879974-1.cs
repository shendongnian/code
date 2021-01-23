            foreach (DataGridViewRow row in dgvNodes.Rows)
            {
                DataGridViewCell cell = row.Cells[6];
                if (!cell.Value.Equals(null) && !cell.Value.Equals(""))
                {
                    cell.Value = int.Parse(cell.Value.ToString());
                }
                else
                {
                    cell.Value = row.Index + 1;
                }
            }
