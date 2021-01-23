    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
        string viewname = "Entries_" + Environment.UserName.ToUpper();
        using (SqlConnection connection = new SqlConnection())
        using (SqlCommand initCmd = new SqlCommand("IF NOT EXISTS(select * FROM sys.views where name = @ViewName) exec dbo.spAddUser @User, @Domain", connection))
        {
            // the connection string is the same one I use to create the DbContext
            connection.ConnectionString = ConfigurationManager.ConnectionStrings["AppConnectionString"].ConnectionString;
            initCmd.Parameters.AddWithValue("ViewName", viewname);
            initCmd.Parameters.AddWithValue("User", Environment.UserName);
            initCmd.Parameters.AddWithValue("Domain", GetDomain());            
            try
            {
                connection.Open();
                initCmd.ExecuteNonQuery();
            }
            catch (SqlException e)
            {
                Debug.WriteLine(e.Message);
                // TODO
            }
        }
        modelBuilder.Entity<Entry>().ToTable(viewname);
        modelBuilder.Entity<Project>().ToTable("Projects");
    }
