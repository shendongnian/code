    public class IndexModel : PageModel
    {
    	public ArticleContainer ArticleContainer { get;set; }
    	
    	private readonly IOptions<ArticleContainer> _articleContainer;
    
    	public IndexModel(IOptions<ArticleContainer> articleContainer)
    	{
    		_articleContainer = articleContainer;
    	}
    
    	public void OnGet()
    	{
    		ArticleContainer = _articleContainer.Value;
    	}
    }
