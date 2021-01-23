    Form1_Load()
    {
    	// This method subscribes to the DataGridView Binding Complete Event. Only after DdataBinding is Complete
            // For example when you do this dataGridView3.DataSource = MySource; or dataGridView3.ResetBindings(false);
           dataGridView3.DataBindingComplete += dataGridView3_DataBindingComplete;
    
           // This Method Subscribes to the Cell Formatting event - will be called when formatting the Cells!
     	dataGridView3.CellFormatting += new DataGridViewCellFormattingEventHandler(dataGridView3_CellFormatting);
    
    // All of my other code that I have in the load event..
    
    }
    
    // This is called when Databinding is complete 
            private void dataGridView3_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
            {
                dgBinContent.ClearSelection();
    
                DataGridView myGrid = (DataGridView)sender;
                for (int i = 0; i < myGrid.Rows.Count - 1; i++)
                {
    
    
                    myGrid.CellBorderStyle = DataGridViewCellBorderStyle.None;
                    DataGridViewCellStyle style = new DataGridViewCellStyle();
                    style.Font = new System.Drawing.Font(myGrid.Font, System.Drawing.FontStyle.Bold);
    
                    int ii = Convert.ToInt32(myGrid.Rows[i].Cells[0].Value.ToString());
                    if (ii % 2 == 0)
                    {
                        myGrid.Rows[i].DefaultCellStyle.BackColor = System.Drawing.Color.Yellow;
                        myGrid.Rows[i].DefaultCellStyle = style;
                        myGrid.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Chocolate;
                    }
                    else
    		{
                        myGrid.Rows[i].DefaultCellStyle.BackColor = System.Drawing.Color.Orange;
    		}
                }
              
             }
    
    // This is called when Cell Formatting
            void dataGridView3_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
            {
                this.dataGridView3.Rows[e.RowIndex].HeaderCell.Value = String.Format("{0}", e.RowIndex + 1);
    
                dataGridView3.CellBorderStyle = DataGridViewCellBorderStyle.None;
                DataGridViewCellStyle style = new DataGridViewCellStyle();
                style.Font = new System.Drawing.Font(dataGridView3.Font, System.Drawing.FontStyle.Bold);
    
                int ii = Convert.ToInt32(dataGridView3.Rows[e.RowIndex].Cells[0].Value.ToString());
                if (ii % 2 == 0)
                {
                    dataGridView3.Rows[e.RowIndex].DefaultCellStyle.BackColor = System.Drawing.Color.Yellow;
                    dataGridView3.Rows[e.RowIndex].DefaultCellStyle = style;
                    dataGridView3.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Chocolate;
                }
                else
                {
                    dataGridView3.Rows[e.RowIndex].DefaultCellStyle.BackColor = System.Drawing.Color.Orange;
                }
    
            }
