    private void textBox5_TextChanged(object sender, EventArgs e)
            {           
                DataView dv = new DataView(dt);
                dv.RowFilter = string.Format("Prece LIKE '%{0}%'", textBox5.Text);
    
                DataTable dtMain=dv.ToTable().Copy();
    
                dv = new DataView(dt2);
                dv.RowFilter = string.Format("Prece LIKE '%{0}%'", textBox5.Text);
                dtMain.Merge(dv.ToTable());
                dv = new DataView(dt3);
                dv.RowFilter = string.Format("Prece LIKE '%{0}%'", textBox5.Text);
                dtMain.Merge(dv.ToTable());
    
                dataGridView1.DataSource = dtMain;
            } 
