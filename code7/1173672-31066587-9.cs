        Dictionary<int, List<int, string>> articles = new Dictionary<int, List<int, string>>();
        
        public void AddComment(int titleNum, string comment) 
        {
            if(!articles.Keys.Contains(titleNum)) { articles.Add(titleNum, new List<string>());
            articles[titleNum].Add(comment);
        }
        
        public List<string> getComment (int titleNum)
        {
           return articles[titleNum];
        }
