    private Dictionary<string, int> GetSummation()
    {
        var kvp = new List<KeyValuePair<string, int>>();
    
        for (var i = 0; i < GridView1.Rows.Count; i++)
        {
            var item = GridView1.Rows[i].Cells[1].Text.Trim();
            var count = Convert.ToInt32(GridView1.Rows[i].Cells[2].Text);
    
            kvp.Add(new KeyValuePair<string, int>(item, count));
        }
    
        return kvp.GroupBy(k => k.Key).ToDictionary(g => g.Key, g => g.Sum(x => x.Value));
    }
