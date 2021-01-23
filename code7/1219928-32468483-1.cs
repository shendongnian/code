    // Seems like you are merging many queries results into a single Table.
    // You can store all the results from the loop into a single Table,
    // then you can DataBind your ListView to it laters.
    DataTable dt = new DataTable();
    foreach (ListItem item in CheckBoxClassRegion.Items)
    {                                                                       
        if (item.Selected == true)                                            
        {                                                                   
            cmd.Parameters.Clear();                                           
            cmd.Parameters.AddWithValue("@TeamName", item.Value);        
    
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            // You can use the Fill method multiple times on the same DataTable.
            // If a primary key exists, incoming rows are merged with matching 
            // rows that already exist. If no primary key exists, incoming rows 
            // are appended to the DataTable.
            da.Fill(dt);
        }
    }
    // Finally, you set the DataSource property and call the DataBind method
    ListView1.DataSource = dt;
    ListView1.DataBind();
