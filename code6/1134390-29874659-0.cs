    public List<string> getSearchResults(string keyword)
    {
        public List<string> results = new List<string>();
        //....
        foreach (DataRow row in results.Rows)
        {
            string cont = row["content"].ToString();
            this.results.Add(cont);
        }
        db.Close();
        return results;
    }
