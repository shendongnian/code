    public void Level1[] GetLevels()
    {
       DataSet ds = ....
       return ds.Tables[0].Rows
           .Select(row => new Level1((string)row["name"]))
           .ToArray();
    }
    
