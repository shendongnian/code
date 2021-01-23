    public class Discssion
    {
        public string Discussion_Title { get; set; }
        public string Discussion_Description { get; set; }
        public string Comment_CreateBy { get; set; }
        public List<DiscussionPreview> DiscussionPreviews{ get;set;}
    }
    public class DiscussionPreview
    {
        public class Comment_Description{ get; set; }
        .....
    }
