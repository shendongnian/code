    using System;
    using System.Data;
    using Npgsql;
    
    public static class NpgsqlUserManual
    {
      public static void Main(String[] args)
      {
        NpgsqlConnection conn = new NpgsqlConnection("Server=127.0.0.1;Port=5432;User Id=joe;Password=secret;Database=joedata;");
        conn.Open();
        
        NpgsqlCommand command = new NpgsqlCommand("SELECT string_agg(NewLanguage,',') FROM Languages", conn);
        String results;
        
        try
        {
          results = (String)command.ExecuteScalar();
          Console.WriteLine("{0}", results);
        }
        
        
        finally
        {
          conn.Close();
        }
      }
    }
