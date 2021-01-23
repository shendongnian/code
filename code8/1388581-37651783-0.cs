            try
            {
                Conn.Open();
                SqlCommand cmd = new SqlCommand("Insert INTO tbl_User(Name,Email,Password) VALUES ('" + name + "','" + email + "','" + password + "')", Conn);
                int restl = cmd.ExecuteNonQuery();
                //temp = true;
                return "Record Inserted successfully!";
            }
            catch (SqlException ex)
            {
                if (ex.Number == 2627)
                {
                    return "Record Already Exists";
                }
                return "Your Text";
            }
            finally
            {
                Conn.Close();
            }
            return "Your Text";
        }
