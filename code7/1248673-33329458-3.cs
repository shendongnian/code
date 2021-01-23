    class Post {
        [Key]
        public int Id{get;set;}
        public DateTime CreationDate{get;set;}
        public virtual string Content{get;set;}
        public int ThreadId{get;set;}  **-> here you used ThreadId which is implicitly a foreignkey for Thread, and that's good**
        public virtual Thread Thread{get;set;}
    }
    
    class Thread {
        [Key]
        public int Id{get;set;}
        public string Title{get;set;}
        public int FirstPostId{get;set;} **-> here you can do the same by changing this to PostId**
        public virtual Post FirstPost{get;set;} **-> and this to Post**
        public List<Post> Replys{get;set;}
    }
