    //Create class to store result value
    public class ClassName
    {
        public string Col1 { get; set; }
        public int Col2 { get; set; }
    }
    // In query code
    ClassName[] allRecords = null;
    SqlCommand command = ...; // your code
    using (var reader = command.ExecuteReader())
    {
        var list = new List<ClassName>();
        while (reader.Read())
            list.Add(new ClassName {Col1 = reader.GetString(0), Col2 = reader.GetInt32(1)});
        allRecords = list.ToArray();
    }
