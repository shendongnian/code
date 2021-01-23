    public static gridObject[] Parse(string str)
    {
        int first = str.IndexOf("[");
        int last = str.LastIndexOf("]");
        str = str.Substring(first, last - first + 1);
        string[] big_parts = str.Split(new string[] {"[", "],[", "]"} , StringSplitOptions.RemoveEmptyEntries);
        return big_parts.Select(x =>
        {
            string[] small_parts = x.Split(',');
            return new gridObject()
            {
                datarow = Convert.ToInt32(small_parts[0]),
                datacol = Convert.ToInt32(small_parts[1]),
                datasizex = Convert.ToInt32(small_parts[2]),
                datasizey = Convert.ToInt32(small_parts[3]),
            };
        }).ToArray();
    }
