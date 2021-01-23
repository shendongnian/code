        private void text_Pnumber_TextChanged(object sender, EventArgs e)
            {
                DataView dv = new DataView(dt);
                m_partNumberFilter=string.Format("[Part Number] LIKE '%{0}%'", text_Pnumber.Text)
                applyFilter();
                dv.RowFilter = m_currentFilter;
                dataGridView1.DataSource = dv;
            }
    
    private void text_Dwgnumber_TextChanged(object sender, EventArgs e)
        {
            DataView dv = new DataView(dt);
           m_drawingNumberFilter= string.Format("[Drawing Number] LIKE '%{0}%'", text_Dwgnumber.Text);
            applyFilter();
            dv.RowFilter = m_currentFilter;
            dataGridView1.DataSource = dv;
        }
