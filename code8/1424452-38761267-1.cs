    string cmdText = @"INSERT INTO  Patient_Details (ID, Name, Age, Gender, [Contact No], Address) 
                       VALUES(@Id, @Name, @Age, @ContactNo, @Address)"
    using (SqlConnection con = new SqlConnection(....))
    {
        con.Open();
        SqlCommand sc = new SqlCommand(cmdText, con);
        sc.Parameters.AddWithValue("@Id", textBox1.Text);
        sc.Parameters.AddWithValue("@Name", textBox2.Text);
        // For the following two fields, add a value or remove 
        // the parameters and fix the query text above....
        sc.Parameters.AddWithValue("@age", ????); 
        sc.Parameters.AddWithValue("@gender", ????);
        sc.Parameters.AddWithValue("@ContactNo", textBox3.Text);
        sc.Parameters.AddWithValue("@Address", textBox5.Text);
        int o = sc.ExecuteNonQuery();
        if(o > 0) 
            MessageBox.Show(o + ":Record has been inserted");
    }
