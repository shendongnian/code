    private static void Main()
    {
        var queryResults = new List<string>();
        foreach (string query in queryList)
        {
            ...
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Console.WriteLine();
                    Console.WriteLine(query  + Environment.NewLine + "{0}", reader.GetString(0));
					queryResults.Add(reader.GetString(0));
                }
            }
            else
            {
                Console.WriteLine("No rows found.");
            }
            reader.Close();
        }
        ...
    }
