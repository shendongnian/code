    public class GridObject
    {
        public int datarow { get; set; }
        public int datacol { get; set; }
        public int datasizex { get; set; }
        public int datasizey { get; set; }
    }
    /// <summary>
    /// MySuperObject class which holds a reference to inner array of integers
    /// </summary>
    public class MySuperObject
    {
        public List<int> Items { get; set; } // Inner array of list of integers
        public MySuperObject()
        {
            Items = new List<int>();
        }
        public override string ToString()
        {
            // Need to override ToString to return something like "[1,2,3,4]"
            var result = "";
            foreach (var item in Items)
            {
                if (result.Length > 0)
                    result += ",";
                result += item.ToString();
            }
            return string.Format("[{0}]", result);
        }
        /// <summary>
        /// Function to generate GridObject from existing set of integers
        /// </summary>
        public GridObject GetGridObject()
        {
            var result = new GridObject();
            if (Items.Count >= 1) result.datarow = Items[0];
            if (Items.Count >= 2) result.datacol = Items[1];
            if (Items.Count >= 3) result.datasizex = Items[2];
            if (Items.Count >= 4) result.datasizey = Items[3];
            return result;
        }
    }
    // Parse functions
    public List<MySuperObject> Parse(string value)
    {
        if (string.IsNullOrEmpty(value))
            throw new ArgumentException("value cannot be null or empty!", "value");
        var result = new List<MySuperObject>();
            
        // First get the indexes of first [ and last ]
        var idxStart = value.IndexOf("[");
        var idxEnd = value.LastIndexOf("]");
        // Check validity
        if (idxStart < 0 || idxEnd < 0 || idxEnd <= idxStart)
            return result; // Return empty list
        value = value.Substring(idxStart, idxEnd - idxStart + 1).Trim();
        // Split by [] after replacing spaces with empty strings (and removing first and last [ and ])
        var arr = value.Replace(" ", "").Trim('[',']').Split(new[] { "],[" }, StringSplitOptions.RemoveEmptyEntries);
        foreach (var str in arr)
        {
            // Construct list of integers with a help of LINQ
            var nums = str.Split(',').Select(t => Convert.ToInt32(t)).ToList();
            // Create and add MySuperObject to existing list which will be returned
            result.Add(new MySuperObject
            {
                Items = new List<int>(nums),
            });
        }
        return result;
    }
