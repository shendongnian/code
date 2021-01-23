    private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
            {
                DataGridViewCellStyle MakeItRed = new DataGridViewCellStyle();
    MakeItRed.BackColor = Color.Red;
    
    //make a whole column red
    dataGridView1.Columns[1].DefaultCellStyle = MakeItRed;
    
    //make a specific cell red
    DataGridViewRow row2 = dataGridView1.Rows[2];
    row2.Cells[2].Style = MakeItRed;
    
            }
