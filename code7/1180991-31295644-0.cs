        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // Change the color of the row if the value on column1 is > 0
            if (e.ColumnIndex == 1 && Convert.ToDecimal(e.Value) > 0)  // Column1
            {
                this.dataGridView1.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Red;  // Set font color red
                this.dataGridView1.Rows[e.RowIndex].DefaultCellStyle.Font = new System.Drawing.Font(this.Font, FontStyle.Bold);   // Set Bold   
            }
            if (e.ColumnIndex == (int)transactionsDGV.AmountDue && Convert.ToDecimal(e.Value) <= 0)  // Column Amount Due
            {
                this.dataGridView1.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Black;  // Set font color black  
            }
        }
