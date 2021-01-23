    using( OracleConnection conn = new OracleConnection( oradb ) )
    {
        conn.Open();
        using( OracleCommand cmd = new OracleCommand( "sql here", conn ) )
        {
            //cmd.Execute(); cmd.ExecuteNonQuery();
        }
    }
