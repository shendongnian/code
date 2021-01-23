    class SummaryRecord
    {
        public int CalcData { get; set; }
        public string Key { get { return Id1 + Id2; } 
        public string Id2 { get; set; }
        public string Id2 { get; set; }
    }
    private HashSet<String> keyToFind = new  HashSet<String>() {"key1","key2"}; 
    var filteredData = from d in dictSummaries.where(x => keyToFind.Contains(x.key));
