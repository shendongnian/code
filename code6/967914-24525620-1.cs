    public void Insert(string f1, string f2)
    {
        string query;
        Connection c = new Connection();
        c.OpenCnn();
        try  
        {
            query = "insert into ..."
            SqlCommand cmd = new SqlCommand(query, c.Conn);
            cmd.ExecuteNonQuery();
        }
        catch (Exception ex){
                   throw ex;
        }
        finally {
           c.CloseCnn();
        }
     }
