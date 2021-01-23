    //get application path and script directory
    private const string scriptPath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Scripts");
    private void RunScripts()
    {
        string[] scripts = Directory.GetFiles(scriptPath, "*.sql", SearchOption.TopDirectoryOnly);
        //name them script01.sql, script02.sql ...etc so they sort correctly
        Array.Sort(scripts);
        if (scripts.Length > 0)
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.AppSettings["ConnectionStringKey"]))
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    foreach (string script in scripts)
                    {
                        cmd.CommandText = File.ReadAllText(script);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
        }
    }
