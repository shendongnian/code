    string connstr = Project304_1.Properties.Settings.Default._20121600ConnectionString;
    using (SqlConnection conn = new SqlConnection(connstr))
    {
        conn.Open();
        using (SqlCommand cmd = new SqlCommand("SELECT * FROM t304_users WHERE userName = @UserName AND password = @Password", conn))
        {
            cmd.Parameters.AddWithValue("@UserName", UserName);
            cmd.Parameters.AddWithValue("@Password", Password);
        
            using (var rdr = cmd.ExecuteReader())
            {
                DataTable dt = new DataTable("Users");
                dt.Load(rdr);
                if (dt.Rows.Count == 1)
                {
                    frmMain main = new frmMain();
                    if (dt.Rows[0][8].ToString() == "admin") // fix this to use a string indexer and not numeric
                    {
                        // handle this
                    }
                    else if (dt.Rows[0][8].ToString() == "staff") // fix this to use a string indexer and not numeric
                    {
                        // handle this
                    }
                    main.Show();
                    this.Hide();
                }
                else
                {
                    // handle this
                }
            }
        }
    }
