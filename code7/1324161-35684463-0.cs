    public class BlogComment
    {
        public int Id { set; get; }
 
        [MaxLength]
        public string Body { set; get; }
 
        public virtual BlogComment Reply { set; get; }
        public int? ReplyId { get; set; }
        public ICollection<BlogComment> Children { get; set; }
    }    
 
    using (var ctx = new MyContext())
                {
                    var list = ctx.BlogComments
                              //.where ...
                              .ToList() // fills the childs list too
                              .Where(x => x.Reply == null) // for TreeViewHelper                        
                              .ToList();
                }
