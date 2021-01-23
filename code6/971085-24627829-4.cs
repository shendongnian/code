    List<Things> RequestThings(Connection conn, int version)
    {
        while (true)
        {
            try 
            {
                // this will either create an entire list,
                // or fail completely
                return connection.RequestThings(version).ToList();
            }
            catch (Exception ex)
            {   
                Log.Error(ex);
                version++;
            }
        }
    }
