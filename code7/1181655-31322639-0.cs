     private NpgsqlConnection _PgConnection;
     public NpgsqlConnection PgConnection
     {
         get
         {
             if (_PgConnection == null)
             {
                NpgsqlConnectionStringBuilder sb = new NpgsqlConnectionStringBuilder();
                sb.Host = "hostname.whatever.com";
                sb.Port = 5432;
                sb.UserName = "scott";
                sb.Password = "tiger";
                sb.Database = "postgres";
                sb.Pooling = true;
                _PgConnection = new NpgsqlConnection(sb.ToString());
             }
             if (!_PgConnection.State.Equals(ConnectionState.Open))
                 _PgConnection.Open();
             return _PgConnection;
         }
         set { _PgConnection = value; }
     }
