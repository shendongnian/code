    public string[] GetMappedKeyCodes()
    {
        var mapping = GetMapping();
        List<string> clone;
        lock (_sync) clone = new List<string>(_receivedCodes);
        
        return clone.Select(code => {
                         string key;
                         return mapping.TryGetValue(code, out key)
                              ? key
                              : null;
                     })
                    .Where(key => !string.IsNullOrEmpty(key))    // skip unmapped values
                    .ToArray();
    }
    private IReadOnlyDictionary<string, string> GetMapping()
    {
        var constring = @"Data Source=.\SQLEXPRESS...";
        using (var conn = new SqlConnection(constring))
        using (var cmd = new SqlCommand("select LETTER, CODE from TABLE;", conn))
        var mappedCodes = new Dictionary<string, string>();
        using (var reader = cmd.ExecuteReader())
        {
            if (reader.MoveNext())
            {
                var codeOrd = reader.GetOrdinal("CODE");
                var letterOrd = reader.GetOrdinal("LETTER");
                do
                {
                    var code = reader.GetString(codeOrd);
                    var letter = reader.GetString(letterOrd);
                    mappedCodes[code] = letter;                
                }
                while (reader.MoveNext());
            }
        }
        return new ReadOnlyDictionary<string, string>(mappedCodes);
    }
    
