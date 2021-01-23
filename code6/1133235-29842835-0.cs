    public class WordViewModel
    {
    	public Word Word { get; set; }
    
    	public IEnumerable<Meaning> WordMeanings { get; set; }
    	public IEnumerable<Example> WordExamples { get; set; }	
    }
