    class LineItem
    {
        [ColumnInfo(Index = 0, MaxLength = 1)]
        public string S0 { get; set; }
    
        [ColumnInfo(Index = 1, MaxLength = 6)]
        public string S1 { get; set; }
    
        [ColumnInfo(Index = 2, MaxLength = 34)]
        public string S2 { get; set; }
    
        [ColumnInfo(Index = 3, MaxLength = 34)]
        public string S3 { get; set; }
    
        [ColumnInfo(Index = 4, MaxLength = 34)]
        public string S4 { get; set; }
    
        [ColumnInfo(Index = 5, MaxLength = 34)]
        public string S5 { get; set; }
    
        [ColumnInfo(Index = 6, MaxLength = 34)]
        public string S6 { get; set; }
        public static LineItem Parse(string line)
        {
            var propertyDictionary =
                typeof(LineItem)
                .GetProperties(BindingFlags.Instance | BindingFlags.Public)
                // create an anonymous object to hold the property and the ColumnInfo
                .Select(p => new
                {
                    Property = p,
                    ColumnInfo = p.GetCustomAttribute<ColumnInfoAttribute>()
                })
                // get only those where the ColumnInfo is not null (in case there are other properties)
                .Where(ci => ci.ColumnInfo != null)
                // create a dictionary with the Index as a key
                .ToDictionary(ci => ci.ColumnInfo.Index);
    
            var result = new LineItem();
    
            var values = line.Split('|');
            for (var i = 0; i < values.Length; i++)
            {
                // validate the length of the value
                var isValidLength = values[i].Length > propertyDictionary[i].ColumnInfo.MaxLength;
                if (!isValidLength)
                {
                    // todo: throw some appropriate exception or do other error handling
                }
    
                // set the corresponding property
                propertyDictionary[i].Property.SetValue(result, values[i]);
            }
            return result;
        }
    }
