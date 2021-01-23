    int result;
    Using (SqlConnection con = New SqlConnection("Data Source=.\\SQLEXPRESS;Initial Catalog=db-ub;Integrated Security=True"))
    {
        con.Open();
        // You don't really care to check up front if the record with id=xx exists because
        // if it doesn't, you get 0 records updated
        Using (SqlCommandcmd As New SqlCommand("UPDATE Visitors SET Day_Out=@dO,Time_Out=@tO WHERE Id=@id", con))
        {
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@id", 1);
            cmd.Parameters.AddWithValue("@dO", DateTime.Now);
            cmd.Parameters.AddWithValue("@tO", DateTime.Now);        
            result = cmd.ExecuteNonQuery();
        }
    
        con.Close()
    } 
    // Check the result. If not 0 - you updated your records
    if (result > 0)
    {
        MessageBox.Show("Updated record OK");
    }
    else
    {
        MessageBox.Show("Failed to update record");
    }
    // I don't know what you do with your form logic
    this.Close();
