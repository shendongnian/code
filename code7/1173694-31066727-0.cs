        public int ArticleNum { get; set; }
        public string Creator { get; set; }
        public DateTime DateCreated { get; set; }
        public List<string> Comments { get; set; }
        
        public Article()
        {
            this.Comments = new List<string>();
        }
        public void AddComment(string comment)
        {
            this.Comments.Add(comment);
        }
        public void RemoveComment(string comment)
        {
            this.Comments.Remove(comment);
        }
    }
