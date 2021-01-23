    Dictionary<string, column> _columnNames = 
            new Dictionary<string, column>{
                {"partID", new column{ name = "ID", show = false, type = typeof(int)}},//false
                {"partName", new column{ name = "Name", show = true, type = typeof(string)}}
            };
    internal override Dictionary<string, column> columnNames
    {
        get
        {
            return _columnNames;
        }
    }
