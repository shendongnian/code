     private void dataGridView1_DataBindingComplete(object sender,      
     DataGridViewBindingCompleteEventArgs e){
           foreach (DataGridViewRow row in dataGridView1.Rows)
            {
            
               foreach (DataGridViewCell cell in row.Cells)
                  {
                     
                 foreach( string word in wordss)
                    
                  if (cell.Value.ToString().ToUpper().Contains(word.ToUpper()))
                    {
                        cell.Style.BackColor = Color.Red;
                    }
            }
        }
    }
