     //number of rows
            int rowNum = GridView1.Rows.Count;
    
            //go through each row
            for (int i = 0; i < rowNum; i++)
            {
                //get the cell text 
                 string corr=  GridView1.Rows[0].Cells[0].ToString();
    
                //set color based on the text in the cell
                 if (corr == "Correct")
                 {
                     GridView1.SelectRow(i);
                     GridView1.SelectedRow.ForeColor = Color.Black;
                     GridView1.SelectedRow.BackColor = Color.Cyan;
                 }
                 else
                 {
                     //do watever
                 }
            }
