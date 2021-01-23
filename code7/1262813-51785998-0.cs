    private void dataGridView1_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
            {
                int wrapLen = 84;
                if ((e.RowIndex >= 0) && e.ColumnIndex >= 0)
                {
                    DataGridViewCell cell = this.dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex];
                    string cellText = cell.Value.ToString();
                    if (cellText.Length >= wrapLen)
                    {
                        cell.ToolTipText = "";
                        int n = cellText.Length / wrapLen;
                        for (int i = 0; i <= n; i++)
                        {
                            int wStart = wrapLen * i;
                            int wEnd = wrapLen * (i + 1);
                            if (wEnd >= cellText.Length)
                                wEnd = cellText.Length;
    
                            cell.ToolTipText += cellText.Substring(wStart, wEnd - wStart) + "\n";
                        }
                    }
                }
            }
