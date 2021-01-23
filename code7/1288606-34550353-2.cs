        private void btnadd_Click(object sender, EventArgs e)
        {          
            bool hasDuplicate=false;
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Cells[0] !=null && row.Cells[0].Value.ToString() == IDtxtbox.Text)
                { 
                    hasDuplicate = true; 
                    break;
                }                   
             }
    
             if(hasDuplicate)
                 label25.Text = "ID was already created,try some other number";
                
              else   
              {
                 label25.Text.Clear();                
                 dataGridView1.Rows.Add(IDtxtbox.Text, Nametxtbox.Text);
              }
                
        }
