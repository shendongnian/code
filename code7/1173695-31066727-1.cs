        public int ArticleNum { get; set; }
        public string Creator { get; set; }
        public DateTime DateCreated { get; set; }
        public List<Comment> Comments { get; set; }
        public Article()
        {
            this.Comments = new List<Comment>();
        }
        public void AddComment(Comment comment)
        {
            this.Comments.Add(comment);
        }
        public void RemoveComment(Comment comment)
        {
            this.Comments.Remove(comment);
        }
    }
    public class Comment
    {
        public string Comment { get; set; }
        public string Creator { get; set; }
        public DateTime DateCreated { get; set; }
    }
