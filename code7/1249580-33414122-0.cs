    public static OtherClass()
    {
        public void RetrieveData(ComboBox comboBox)
        {
            SqlConnection con = new SqlConnection(connection_string);
            string select_string = "SELECT * FROM dbo.Categories";
            SqlCommand cmd = new SqlCommand(select_string, con);
    
            SqlDataReader myReader;
            con.Open();
    
    myReader = cmd.ExecuteReader();
    
    while (myReader.Read())
    {
        comboBox.Items.Add(myReader[1]); 
    }
    
    myReader.Close();
    con.Close();
        }
    }
