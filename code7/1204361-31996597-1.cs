        public ActionResult Index()
        {
            var builder = new SqlConnectionStringBuilder();
            builder.DataSource = "localhost";
            builder.IntegratedSecurity = true;
            builder.InitialCatalog = "test";
            XDocument doc = null;
            using (var conn = new SqlConnection(builder.ConnectionString))
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "exec sp_xmlresult";
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                            doc = XDocument.Parse(reader[0].ToString());
                    }
                }
            }
            return View(doc);
        } 
