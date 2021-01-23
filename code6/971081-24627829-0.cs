    void RequestThings(List<Things> container, Connection conn, int lastVersion)
    {
        while (true)
        {
            var version = lastVersion;
            try 
            {
                foreach(var thing in connection.RequestThings(version))
                {
                    container.Add(thing);
                    version = thing.lastVersion;
                }
                
                return;
            }
            catch (Exception ex)
            {   
                Log.Error(ex);
                version++;
            }
        }
    }
