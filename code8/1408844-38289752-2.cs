    class Company
    {
        public Company()
        {
            SearchKeywords = new List<SearchKeyword>();
        }
        public int ID { get; set; }
        public string Name { get; set; }
    
        public virtual OtherDetail OtherDetails { get; set; }
        public virtual ICollection<SearchKeyword> SearchKeywords { get; set; }
    }
