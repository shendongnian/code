    int CheckedRadioButtonValue = Session["CheckedRadioButtonValue "]; // perhaps a query string would be better here
    using (SqlConnection conn = new SqlConnection(connectionString))
    {
        
        SqlCommand cmd = new SqlCommand("SELECT Question FROM Questions WHERE QuestionID = @QuestionID");
        cmd.Parameters.AddWithValue("@QuestionID", CheckedRadioButtonValue);
        cmd.Connection = conn;
        conn.Open();
        cmd.ExecuteScalar().ToString();
    }
