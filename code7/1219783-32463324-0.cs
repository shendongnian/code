    private static void Main(string[] args) {
            var termsTable = new DataTable();
            var suggestionList = new List<string>() {"one", "two", "three"};
            termsTable.Columns.Add(new DataColumn("value", typeof (string)));
            foreach (var term in suggestionList) {
                termsTable.Rows.Add(term);
            }
            using (var conn = new SqlConnection(@"data source=(LocalDb)\v11.0;initial catalog=TestDB;integrated security=True;")) {
                conn.Open();
                using (var cmd = new SqlCommand("select NAME from tl_2014_39_places pl where exists (select 1 from @terms where pl.NAME like '%' + value + '%') ", conn)) {
                    cmd.Parameters.Add(new SqlParameter("terms", SqlDbType.Structured) {
                        Value = termsTable,                        
                        TypeName = "dbo.StringList"
                    });
                    using (var reader = cmd.ExecuteReader()) {
                        while (reader.Read()) {
                            Console.WriteLine(reader[0]);
                        }
                    }
                }
            }
            Console.ReadKey();
        }
