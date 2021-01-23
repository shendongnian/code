    // Seems like you are merging many queries results into a single Table.
    // You can store all the results from the loop into a single Table,
    // then you can DataBind your ListView to it laters.
    DataTable fullTable = new DataTable();
    
    foreach (ListItem item in CheckBoxClassRegion.Items)
    {                                                                       
        if (item.Selected == true)                                            
        {                                                                   
            cmd.Parameters.Clear();                                           
            cmd.Parameters.AddWithValue("@TeamName", item.Value);        
    
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable partialTable = new DataTable();
    
            // Fill the partial DataSet into a partial DataTable.
            da.Fill(partialTable);
            
            // Now, import the rows to the full DataTable.
            foreach (DataRow row in partialTable.Rows)
            {
                fullTable.ImportRow(row);
            }
        }
    }
    
    // Finally, you set the DataSource property and call the DataBind method
    ListView1.DataSource = dt;
    ListView1.DataBind();
