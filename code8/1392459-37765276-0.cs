    int i = 0;
    
    foreach (DataGridViewRow item in this.dataGridView1.SelectedRows)
    {
        con.Open();
        SqlCommand cmdo = new SqlCommand(@" update inventory set category = '"+textBox1.Text+"' WHERE id='" + dataGridView1.SelectedRows[i].Cells[0].Value.ToString() + "'", con);
        cmdo.ExecuteNonQuery();
        con.Close();
        i++;
    }
    
        
