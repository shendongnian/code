    void Main()
    {
    	var art = new Article(1,"2", new ArticleFamily(1, "Test"));
    	art.Family.Description = "What?"; // Won't work
    	
    	var fam = art.Family as ArticleFamily;
    	fam.Description = "This works"; // This works...
    	
    }
    
    public class Article
    {
    	public Article(long ID, string Name, IArticleFamily Family)
    	{
    		//...Initializer...
    	}
    	public IArticleFamily Family { get; set; }
    	//Other props...
    }
    
    public class ArticleFamily : IArticleFamily
    {
    	public ArticleFamily(int ID, string Description)
    	{
    		//...Initializer...
    	}
    	public int ID { get; private set; }
    	public string Description { get; set; }
    }
    
    public interface IArticleFamily
    {
    	int ID { get; }
    	string Description { get;}
    }
