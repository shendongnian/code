        Dictionary<int, List<string>> articles = new Dictionary<int, List<string>>();
        
        public void AddComment(int titleNum, string comment) 
        {
            if(!articles.Keys.Contains(titleNum)) articles.Add(titleNum, new List<string>());
            articles[titleNum].Add(comment);
        }
        
        public List<string> getComment (int titleNum)
        {
           return articles[titleNum];
        }
