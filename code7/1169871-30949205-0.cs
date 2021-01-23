    public List<string> populateDates(string id)
    {
        List<string> dates = new List<string>();
    
        for (int i = 1; i < table.Columns.Count; i++)
        {
            dates.Add(table.Rows[1][i].ToString());
        }
        
        return dates;
    }
