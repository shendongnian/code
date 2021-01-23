    public partial class Default : PageBase
            {
                [Inject]
                public IPostRepository _postRepository { get; set; }
    
                protected void Page_Load(object sender, EventArgs e)
                {
                    Post post = _postRepository.Get(int postId);
                }
            }
