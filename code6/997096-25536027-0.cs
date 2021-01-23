    private void auto_Click(object sender, EventArgs e)  // Build string and then run to test and have user scroll through data  'test' 'run' after they view save,          dynamic or showing up, character check
        {
            //DataTable changed = new DataTable();
            // changed =  dt.GetChanges();
            
            where_Clause = "((";
            row_Count = auto_GridView1.Rows.Count;                // SHould the datagridview or the data rows be counted
            column_count = auto_GridView1.Columns.Count;
   
            for (int i = 0; i < row_Count - 1; i++)     // Begins by selecting the row
            {
                char[] MyChar = { 'A', 'N', 'D', ' ' };   
                 where_Clause = where_Clause.TrimEnd(MyChar);                // Trims in the loop however doesnt pick up the last AND Still leaves last one
                
                if (i > 0 )    // Adds the 'OR' after Row [0] b/c 'OR' isnt needed at row[0]
                {
                  where_Clause = where_Clause + "  ) OR ( ";    
                }
                for (j = 0; j < column_count - 1; j++)     // Loops through all the columns in a given row 
                {
                   
                    if (dt.Rows[i][j].ToString() != "")        // Checks to see if there is a value in the box. If so it adds it to the Clause
                    
                    {
                         header = "";
                         string current_cell = "";
                        header = get_correct_header(j);  // Use j to get the header ]
                        current_cell = dt.Rows[i][j].ToString(); // gets the current selection
                        current_cell = insert_correctHeader(current_cell, header); // reads throught he string pickling up the necessary symbols and inserting in the correct header name 
                        where_Clause += (i < column_count - 1) ?   current_cell + " AND " : string.Empty;   // USE DATA TABLE
                                           
                    }
                
   
                }
                
            }
            char[] Mychar2 = { 'A', 'N', 'D', ' ' };           // Trim again to get rid of that final AND 
            where_Clause = where_Clause.TrimEnd(Mychar2); 
            where_Clause = where_Clause + "))";
            
            MessageBox.Show(where_Clause);  // We have the where clause here must be tested to see if it works
