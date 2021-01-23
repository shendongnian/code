    public class Blog {
        public string Url { get; set; }
        public List<Post> Posts { get; set; } // <<<
    }
    public class Post {
        public string Title { get; set; }
        public string Content { get; set; }
    }
