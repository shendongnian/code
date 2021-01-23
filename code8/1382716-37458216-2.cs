    public int[,] ArrayFromString(string toConvert)
    {
        string[] rows = toConvert.Split('.');
        string[] elements = rows[0].Split(',');
        int[,] result = new int[rows.Length, elements.Length];        
        for (int a = 0; a < rows.Length; a++)
        {
            string[] items = rows[a].Split(',');
            for (int b = 0; b < items.Length; b++)
            {
                result[a,b] = Convert.ToInt32(items[b]);
            }
        }       
    
        return result;
    }
