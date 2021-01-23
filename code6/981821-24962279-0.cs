        {
            dt = new DataTable();
            dt.Columns.Add("Cat");
            dt.Columns.Add("Dog");
          
            dataGridView1.AllowUserToAddRows = true;
            dataGridView1.DefaultValuesNeeded += dataGridView1_DefaultValuesNeeded;
     
            dataGridView1.DataSource = dt;          
        }
        void dataGridView1_DefaultValuesNeeded(object sender, DataGridViewRowEventArgs e)
        {
            var dgv = sender as DataGridView;
            if(dgv == null)
               return;
            e.Row.Cells["Cat"].Value = "Meow";
            e.Row.Cells["Dog"].Value = "Woof";
            
            // This line will commit the new line to the binding source
            dgv.BindingContext[dgv.DataSource].EndCurrentEdit();
        }
