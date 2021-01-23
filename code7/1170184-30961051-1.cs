    int? result = null; // note nullable int
    try
    {
        Using (SqlConnection con = New SqlConnection("Data Source=.\\SQLEXPRESS;Initial Catalog=db-ub;Integrated Security=True"))
        {
            con.Open();
            // You don't really care to check up front if the record with id=xx exists because
            // if it doesn't, you get 0 records updated
            // unless you do something with the result of that query
            Using (SqlCommandcmd As New SqlCommand("UPDATE Visitors SET Day_Out=@dO,Time_Out=@tO WHERE Id=@id", con))
            {
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@id", 1); // <<-- Are you always passing "1"?????
                cmd.Parameters.AddWithValue("@dO", DateTime.Now);
                cmd.Parameters.AddWithValue("@tO", DateTime.Now);        
                result = cmd.ExecuteNonQuery();
            }
    
            con.Close()
        } 
    }
    catch 
    {
        // optionally, log error or show error msg in second msgBox below. Save it to a variable here
    }
 
    // Separate query and result processing
    // Check the result. If result is still null, your query failed. If not 0 - you updated your records
    if (result != null && (int)result > 0)
    {  
        MessageBox.Show("Updated record OK");
    }
    else
    {
        if (result == null)
        {  
            MessageBox.Show("The construct failed"); // optionally add error msg here
        }
        else
        {
           MessageBox.Show("The record I was looking for is not in DB"); 
        }
    }      
    // I don't know what you do with your form logic
    this.Close();
