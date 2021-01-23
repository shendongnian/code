    SqlConnection sqlConnection1 = new SqlConnection("Your Connection String");
    SqlCommand cmd = new SqlCommand();
    SqlDataReader reader;
    cmd.CommandText = "SELECT * FROM Customers";
    cmd.CommandType = CommandType.Text;
    cmd.Connection = sqlConnection1;
    sqlConnection1.Open();
    reader = cmd.ExecuteReader();
    // Data is accessible through the DataReader object here.
    sqlConnection1.Close();
