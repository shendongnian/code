    public class Posting
    {
        public Posting()
        {
            GetPostingChoice = new List<Choice>();
        }
        public int Key1 { get; set; }        
        public List<Choice> GetPostingChoice { get; set; }
    }
