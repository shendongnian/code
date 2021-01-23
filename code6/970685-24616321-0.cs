    static void Main(string[] args)
    {
        int[] select = new int[] { 1, 3, 4, 6, 7, 8 };
        string[] lines = File.ReadAllLines("TextFile1.txt");
    
        var q = lines.Skip(1).Select(l => new {
            Id = Int32.Parse(GetValue(l, 0, 6)),
            Name = GetValue(l, 6, 11),
            Value1 = GetValue(l, 17, 11),
            Value2 = GetValue(l, 28, 13),
            Value3 = GetValue(l, 41, 14),
            Value4 = GetValue(l, 55, 13),
        }).Where(o => select.Contains(o.Id));
    
        var r = q.ToArray();        
    }
    
    static string GetValue(string line, int index, int length)
    {
        string value = null;
        int lineLength = line.Length;
    
        // Take as much of the line as we can up to column length
        if(lineLength > index)            
            value = line.Substring(index, Math.Min(length, lineLength - index)).Trim();
                
        // Return null if we just have whitespace
        return String.IsNullOrWhiteSpace(value) ? null : value;
    }
