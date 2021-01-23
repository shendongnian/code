            foreach (ConnectionStringSettings css in ConfigurationManager.ConnectionStrings)
            {
                ConnectionString conn = new ConnectionString();
                if (!(css.Name == "LocalSqlServer" || css.Name == "LocalMySqlServer"))
                {
                    conn.name = css.Name;
                    conn.conString = css.ConnectionString;
                    conn.provider = css.ProviderName;
                    conStr.Add(conn);
                }
            }
