    Dictionary<string, int> values = new Dictionary<string,int>();
    
    int total = 0;
    values.Add("item1", 2249);
    values.Add("item2", 1769);
    values.Add("item3", 3099);
    values.Add("item4", 1198);
    values.Add("item5", 1899);
    
    
    foreach( CheckBox cb in this.Controls.OfType<CheckBox>()
                                .Where(c=>c.Checked))
    {
        int itemprice;
        if(values.TryGetValue("item"+ Regex.Match(cb.Text, @"\d+").Value, out itemprice))
        {
             total+=itemprice;
        }
    }
 
