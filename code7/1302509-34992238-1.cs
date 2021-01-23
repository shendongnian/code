    public Category
    {
        [Key]
        public int Id {get;set;}
        public string Name {get;set;}
        //For the many to 1 relationship
        public virtual ICollection <PostCategory> PostCategories{get;set;}
        //You wont need this anymore
        //public virtual List<Post> Posts {get;set;}
    }
