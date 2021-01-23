    class GroupItem
    {
        public string Item { set; get; }
        public string[] Data { set; get; }
        public int Count { set; get; }
                
        public GroupItem(string n, string[] d, int c)
        {
            Item = n;
            Data =  d;
            Count = c;
        }
        public override string ToString()
        {
            return string.Join(";", Data);
        }
    }
