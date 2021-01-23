            if (username.Equals("sa", StringComparison.OrdinalIgnoreCase))
            {
                using (SqlConnection conn = new SqlConnection(string.Format("Server={0};Initial Catalog={1};", sqlConn.DataSource, sqlConn.Database)))
                {
                    var securePassword = new System.Security.SecureString();
                    foreach (char character in password)
                    {
                        securePassword.AppendChar(character);
                    }
                    securePassword.MakeReadOnly();
                    var credentials = new SqlCredential(username, securePassword);
                    conn.Credential = credentials;
                    conn.Open();
                    return true;
                }
            }
