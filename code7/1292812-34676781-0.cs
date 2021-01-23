    #r "C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\.NETFramework\v4.5\System.Data.dll"
    #r "C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\.NETFramework\v4.5\System.Xml.Linq.dll"
    using System.Xml.Linq;
    using System.IO.Compression;
    
    public void DecompressDatabaseMigration(string migrationName, string databaseName)
    {
        var connectionString = $@"Data source=.\sqlexpress;Initial catalog={databaseName};Integrated security=true";
        var sqlToExecute = String.Format("select model from __MigrationHistory where migrationId like '%{0}'", migrationName);
    
        using (var connection = new SqlConnection(connectionString))
        {
            connection.Open();
    
            var command = new SqlCommand(sqlToExecute, connection);
    
            var reader = command.ExecuteReader();
            if (!reader.HasRows)
            {
                throw new Exception("Now Rows to display. Probably migration name is incorrect");
            }
    
            while (reader.Read())
            {
                var model = (byte[])reader["model"];
                var decompressed = Decompress(model);
                File.WriteAllText(@"C:\temp\edmx.xml", decompressed.ToString());
            }
        }
    }
    
    public XDocument Decompress(byte[] bytes)
    {
        using (var memoryStream = new MemoryStream(bytes))
        {
            using (var gzipStream = new GZipStream(memoryStream, CompressionMode.Decompress))
            {
                return XDocument.Load(gzipStream);
            }
        }
    }
    DecompressDatabaseMigration(Args[1], Args[0]);	
