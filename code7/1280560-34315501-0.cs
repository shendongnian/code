    foreach (GridViewRow row in GridView1.Rows)
    {
       f_name = ((TextBox)row.FindControl("TextBox1")).Text;
       //etc. 
       using (SqlConnection conn = new SqlConnection(yourConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("yourStoredProcedure", conn))
                {
                   cmd.CommandType = System.Data.CommandType.StoredProcedure;
                   cmd.Parameters.AddWithValue("@f_name", f_name);
                   //etc.
                   conn.Open();
                   cmd.ExecuteNonQuery();
                   conn.Close();
                }
            }
    }
