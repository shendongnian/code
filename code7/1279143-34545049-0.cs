            SqlConnection con = Connection.DBconnection();
            {
                SqlCommand com = new SqlCommand("sp_insertsearchtext", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@condition",idsearch.Text.Trim()); 
                com.Parameters.AddWithValue("@searchtext",searchtext.Text.Trim());               
                com.ExecuteNonQuery();
            }
        }
    protected void GridView1_SelectedIndexChanged(Object sender, EventArgs e)
        {
            int index = GridView1.SelectedIndex;
            hiddenfield.Value = index.ToString();
        }
