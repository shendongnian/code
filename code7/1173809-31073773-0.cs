    private void button2_Click(object sender, EventArgs e)
            {
                const int limitRows = 100;
                var col1 = new DataGridViewTextBoxColumn();
                var col2 = new DataGridViewTextBoxColumn();
                var col3 = new DataGridViewTextBoxColumn();
                gridProduct.AutoGenerateColumns = false;
                gridProduct.RowHeadersVisible = false;
                gridProduct.ColumnHeadersVisible = true;
    
                gridProduct.Columns.Add(col1);
                gridProduct.Columns.Add(col2);
                gridProduct.Columns.Add(col3);
    
                var colIndex = 0;
                int rowIndex = 0;
                for (int i = 0; i <= 200; i++)
                {
                    if (i == limitRows)
                    {
                        colIndex = 1;
                        rowIndex = 0;
                    }
                    else if (i > limitRows)
                        rowIndex++;
                    else
                        rowIndex = gridProduct.Rows.Add();
    
                    gridProduct.Rows[rowIndex].Cells[colIndex].Value = string.Format("Val for row {0}", i);
                    gridProduct.Rows[rowIndex].Cells[2].Value = string.Format("Another val for row {0}", i);
                }
            }
