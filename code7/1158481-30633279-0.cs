    private static void Main(string[] args)
    {
        using (
            var conn =
                new SqlConnection(
                    "Server=************.database.windows.net,0000;Database=testdb;User ID=testuser;Password= testpassword;Trusted_Connection=False;Encrypt=True;Connection Timeout=30;")
            )
        {
            conn.Open();
            using (
                var cmd =
                    new SqlCommand(
                        "SELECT * FROM District WHERE leaID <= 4 FOR XML PATH('districtEntry'), ROOT('districts')",
                        conn))
            {
                using (var reader = cmd.ExecuteXmlReader())
                {
                    var doc = XDocument.Load(reader);
                    string path = @"District." + DateTime.Now.ToString("yyyyMMdd") + ".xml";
                    using (var writer = new StreamWriter(path))
                    {
                        doc.Save(writer);
                    }
                }
            }
        }
    }
