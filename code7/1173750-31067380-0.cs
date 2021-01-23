    var lines = new System.IO.Files.ReadLines(@"C:\Users\Malik\Desktop\research_fields.txt");
     while (reader.Read())
    {
        summary = reader["p_abstract"].ToString();
        dd.AddRange(lines.Select( line => 
            Tuple.Create(line, p.calculate_CS(line, summary), summary)
        ); 
        // rest of your stuff
    }
