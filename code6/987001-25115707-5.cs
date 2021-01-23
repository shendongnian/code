    public class Posting
    {
    
        public int Key1 { get; set; }        
        public List<Choice> GetPostingChoice { get; set; }
    	public Posting()
    	{
    		GetPostingChoice = new List<Choice>();
    	}
    }
