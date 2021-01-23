        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)    
        {
            if (e.ColumnIndex == 1 )   // Change int Value Of The Column
            {
                if (!ReferenceEquals(e.Value, DBNull.Value))    // You don't need this check if you are not doing any conversion of the e.Value to a numeric value.
                {
                    if (e.Value.ToString() == "0") // Change colour and value to blue.  
                    {
                       // Use this lines to change the color of just the cell
                        DataGridViewCellStyle style = new DataGridViewCellStyle();
                        style.BackColor = Color.Blue;
                        style.ForeColor = Color.White;
                        style.Font = new System.Drawing.Font("Arial", 10, FontStyle.Regular);
                        e.CellStyle = style;
                        e.Value = "BLUE";                     
                    }
                    if (e.Value.ToString() == "1")  // Change colour and value to green
                    {
                        // Use this lines to change the color of just the cell
                        DataGridViewCellStyle style = new DataGridViewCellStyle();
                        style.BackColor = Color.Green;
                        style.ForeColor = Color.White;
                        style.Font = new System.Drawing.Font("Arial", 10, FontStyle.Regular);
                        e.CellStyle = style;
                        e.Value = "GREEN";
                    }
                }
            }
        }
