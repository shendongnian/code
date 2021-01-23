    public boolean CheckConnection(DbConnection connection) 
    {
        try
        {
            connection.Open();
            connection.Close();
            return true;
        }
        catch (DbException)
        {
            // Le catch n'a pas de raison d'être, la variable étant à false par défaut.
        }
        return false;
    }
