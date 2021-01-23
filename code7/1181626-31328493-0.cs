    private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
    {
        // Change the font color of the row if the textBox1.Text string matches a value on the dataGridView
        if (textBox1.Text == Convert.ToString(e.Value))
        {
            this.dataGridView1.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Red;  // Set font color red
            this.dataGridView1.Rows[e.RowIndex].DefaultCellStyle.Font = new System.Drawing.Font(this.Font, FontStyle.Bold);   // Set Bold   
        }            
    }
