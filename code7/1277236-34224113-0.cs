    private void delete_btn_Click(object sender, EventArgs e)
        {
            try
            {
    		foreach (void row_loopVariable in dataGridView1.Rows) 
    		{
    		 row = row_loopVariable;
    	     if (row.Cell[0].Text == TextBox1.tex) 
    		 {
    			//delete opration here for TextBox1.tex/row.Cell[0].Text(Product_id)
    			break;
    		 }
    				
    		}
               
            }
            catch (System.Exception)
            {
                MessageBox.Show("Not able to Delete");
            }
        }
