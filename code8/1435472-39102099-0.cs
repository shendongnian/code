     private void dataGridView1_RowValidated(object sender, DataGridViewCellEventArgs e){
                SqlCommandBuilder cb;
                dt = new DataTable();
                dt = ((DataTable)dataGridView1.DataSource).GetChanges();
                if (ds != null)
                {
                    cb = new SqlCommandBuilder(adp);
                    adp.UpdateCommand = cb.GetUpdateCommand(true);
                    adp.Update(dt);
                }
    
    }
