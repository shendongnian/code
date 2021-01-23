        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            string originalCell;
            string reformattedCell;
            if (this.dataGridView1.Columns[e.ColumnIndex].Name == "col1")
            {
                if(e.Value != null)
                {
                    DataGridViewCell cell = 
                        this.dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex];
                    originalCell = e.Value.ToString();
                    if (originalCell.Count(c => c == '*') == 2)
                    {
                        reformattedCell = originalCell.Replace("**", "");
                        cell.Value = reformattedCell;
                        cell.Style.BackColor = Color.Red;
                        cell.ToolTipText = "Divisible by 5";
                    }
                    else if (originalCell.Count(c => c == '*') == 1)
                    {
                        reformattedCell = originalCell.Replace("*", "");
                        cell.Value = reformattedCell;
                        cell.Style.BackColor = Color.Red;
                        cell.ToolTipText = "Divisible by 7";
                    }
                    else
                    {
                        //do nothing
                    }
                }
            }
            if (this.dataGridView1.Columns[e.ColumnIndex].Name == "col2")
            {
                if (e.Value != null)
                {
                    DataGridViewCell cell =
                        this.dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex];
                    originalCell = e.Value.ToString();
                    if (originalCell.Count(c => c == '*') == 2)
                    {
                        reformattedCell = originalCell.Replace("**", "");
                        cell.Value = reformattedCell;
                        cell.Style.BackColor = Color.Red;
                        cell.ToolTipText = "Divisible by 5";
                    }
                    else if (originalCell.Count(c => c == '*') == 1)
                    {
                        reformattedCell = originalCell.Replace("*", "");
                        cell.Value = reformattedCell;
                        cell.Style.BackColor = Color.Red;
                        cell.ToolTipText = "Divisible by 7";
                    }
                    else
                    {
                        //do nothing
                    }
                }
            }
            if (this.dataGridView1.Columns[e.ColumnIndex].Name == "col3")
            {
                if (e.Value != null)
                {
                    DataGridViewCell cell =
                        this.dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex];
                    originalCell = e.Value.ToString();
                    if (originalCell.Count(c => c == '*') == 2)
                    {
                        reformattedCell = originalCell.Replace("**", "");
                        cell.Value = reformattedCell;
                        cell.Style.BackColor = Color.Red;
                        cell.ToolTipText = "Divisible by 5";
                    }
                    else if (originalCell.Count(c => c == '*') == 1)
                    {
                        reformattedCell = originalCell.Replace("*", "");
                        cell.Value = reformattedCell;
                        cell.Style.BackColor = Color.Red;
                        cell.ToolTipText = "Divisible by 7";
                    }
                    else
                    {
                        //do nothing
                    }
                }
            }
            if (this.dataGridView1.Columns[e.ColumnIndex].Name == "col4")
            {
                if (e.Value != null)
                {
                    DataGridViewCell cell =
                        this.dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex];
                    originalCell = e.Value.ToString();
                    if (originalCell.Count(c => c == '*') == 2)
                    {
                        reformattedCell = originalCell.Replace("**", "");
                        cell.Value = reformattedCell;
                        cell.Style.BackColor = Color.Red;
                        cell.ToolTipText = "Divisible by 5";
                    }
                    else if (originalCell.Count(c => c == '*') == 1)
                    {
                        reformattedCell = originalCell.Replace("*", "");
                        cell.Value = reformattedCell;
                        cell.Style.BackColor = Color.Red;
                        cell.ToolTipText = "Divisible by 7";
                    }
                    else
                    {
                        //do nothing
                    }
                }
            }
        }
