    public class CreatePostViewModel
    {
        public int Id { set; get; }
        [Required]
        public string Title { set; get; }
        [Required]
        public string CustomerName { set; get; }
        public HttpPostedFileBase BlogImage { set; get; }
        public HttpPostedFileBase BlogLogo { set; get; }
    }
