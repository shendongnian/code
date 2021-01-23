    public class PostDto
    {
        public string Title{ set; get; }
        public int Id { set; get; }  
  
        public List<PostDto> Comments { set; get; }
    
        public int TotalCommentCount { set; get; }
    }
