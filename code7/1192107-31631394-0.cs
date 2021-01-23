    using (var conn = new NpgsqlConnection(this.RealEsateDB))
    {
        conn.Open();
        
        using (NpgsqlTransaction t = conn.BeginTransaction()) 
        {
            using (var cmd = conn.CreateCommand())
            {
                ...
            }
            t.Commit();
        }
    }
