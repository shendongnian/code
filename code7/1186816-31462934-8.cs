    public class NumberSequence
    {
    	// numbers to be compared
    	private readonly List<int> numbers = new List<int>();
    	// used to generate a random collection
    	private readonly Random random = new Random();
    	// tell me if the previous and next number are different
    	public event EventHandler DifferentNumbersEvent;
    	
    	public NumberSequence()
    	{
    		// fill the list with random numbers
    		Enumerable.Range(1, 100).ToList().ForEach(number =>
    		{
    			numbers.Add(random.Next(1, 100));
    		});
    	}
    	
    	public List<int> Numbers { get { return numbers; } }
    	
    	public void TraverseList()
    	{
    		for (var i = 1; i < this.numbers.Count; i++)
    		{
    			if (this.numbers[i - 1] != this.numbers[i])
    			{
    				if (this.DifferentNumbersEvent != null)
    				{
    					// whoever listens - inform him
    					this.DifferentNumbersEvent(this, EventArgs.Empty);
    				}
    			}
    		}
    	}
    }
