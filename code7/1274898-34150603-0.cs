    public ActionResult Index()
    {
        string scriptDirectory = "e:\\";
        string sqlConnectionString = "Integrated Security=SSPI;" +
            "Persist Security Info=True;Initial Catalog=TestDB;Data Source=localhost\\SQLEXPRESS";
        using(var connection = new SqlConnection(sqlConnectionString))
        {
            var transaction = connection.BeginTransaction();
            using(var command = connection.CreateCommand())
            {
                ProcessFiles(command, scriptDirectory);
            }
            transaction.Commit();
        }
        return View();
    }
    private void ProcessFiles(SqlCommand command, string scriptDirectory)
    {
        foreach(var file in Directory.GetFiles(scriptDirectory,"*.sql"))
        {
            using(var reader = new StreamReader(file))
            {
                while(!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    if(!line.StartsWith("GO"))
                    {
                        command.CommandText = line;
                        command.ExecuteNonQuery();
                    }
                }
            }
        }        
    }
