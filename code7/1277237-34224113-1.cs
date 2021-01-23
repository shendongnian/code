    private void delete_btn_Click(object sender, EventArgs e)
        {
            try
            {
    		foreach (GridViewRow row in dataGridView1.Rows) 
    		{
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
