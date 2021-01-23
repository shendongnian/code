        Form1_Load()
        {
        
        dataGridView4.OnBindingComplete += SetGridViewRows;
        ... // the rest of your code...
        
        }
    
    SetGridViewRows(object sender, BindingCompleteEventArgs e)
    {
    
        DataGridViewCellStyle st = new DataGridViewCellStyle();
        st.Font = new Font("Arial", 12, FontStyle.Bold);
    
        for (int i = 0; i < dataGridView4.Rows.Count-1; i++)
        {
            //dataGridView4.RowsDefaultCellStyle.BackColor = Color.Orange;
            //dataGridView4.AlternatingRowsDefaultCellStyle.BackColor = Color.BurlyWood;
    
            int ii = Convert.ToInt32(dataGridView4.Rows[i].Cells[0].Value.ToString());
            if (ii % 2 == 0)
            {
                dataGridView4.Rows[i].DefaultCellStyle.BackColor = Color.Gray;
                dataGridView4.Rows[i].DefaultCellStyle = st;
            }
            else
                dataGridView4.Rows[i].DefaultCellStyle.BackColor = Color.Brown;
        }
    
    
    }
