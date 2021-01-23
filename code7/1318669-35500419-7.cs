    public bool CheckConnection(DbConnection connection) 
    {
        try
        {
            connection.Open();
            connection.Close();
            return true;
        }
        catch (Exception)
        {
            // Le catch n'a pas de raison d'être, la variable étant à false par défaut.
        }
        return false;
    }
