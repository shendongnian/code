        try
        {
            SqlConnection con = new SqlConnection(connection_string);
            con.Open();
            SqlCommand command = new SqlCommand("SELECT * FROM tblMyCart WHERE Product_Category='" + catid + "'");
            command.Connection = con;
            SqlDataReader red = command.ExecuteReader();
            if (red.HasRows)
            {
                return false;
            }
            else
                return true;
        }
        catch
        {
            throw;
        }       
    }
