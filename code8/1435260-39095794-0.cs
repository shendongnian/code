    private static readonly char[] WordSeparator = { ' ', '\t', ',', '.', ':' }; // to be continued
    // ....
    HashSet<string> allUniqueWords = new HashSet<string>();
    using (var con = new SqlConnection(Properties.Settings.Default.ConnectionString))
    using (var cmd = new SqlCommand("SELECT DISTINCT ColumnName FROM dbo.TableName", con))
    {
        con.Open();
        using (var rd = cmd.ExecuteReader())
        {
            string[] words = rd.GetString(0).Split(WordSeparator, StringSplitOptions.RemoveEmptyEntries);
            foreach (string word in words)
                allUniqueWords.Add(word);
        }
    }
