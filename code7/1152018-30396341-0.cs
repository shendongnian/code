            if (this.dgv_tasks.Columns[e.ColumnIndex].Index == 3)
            {
                if (e.Value != null)
                {
                    DateTime dateValues = DateTime.Parse(dgv_tasks.Rows[e.RowIndex].Cells[3].Value.ToString());
                    DateTime dateNow = DateTime.Now;
                    if ((dateValues - dateNow).TotalDays < 7)
                    {
                        e.CellStyle.BackColor = Color.Yellow;
                    }
                    if (dateValues < dateNow)
                    {
                        e.CellStyle.BackColor = Color.Pink;
                    }
                }
            }
        }`
