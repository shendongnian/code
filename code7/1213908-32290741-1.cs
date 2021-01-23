    public class Calc
    {
    	int total = 0;
    	Stack<int> stack = new Stack<int>();
    	Action lastCommand;
    
    	public int Value
    	{
    		get { return total; }
    		set { Execute(() => total = value); }
    	}
    
    	public void Add(int value)
    	{
    		Execute(() => total += value);
    	}
    
    	public void Subtract(int value)
    	{
    		Execute(() => total -= value);
    	}
    
    	public void Multiply(int value)
    	{
    		Execute(() => total *= value);
    	}
    
    	public void Divide(int value)
    	{
    		Execute(() => total /= value);
    	}
    
    	public void Negate()
    	{
    		Execute(() => total = -total);
    	}
    
    	public void RepeatLastCommand()
    	{
    		if (lastCommand != null)
    			lastCommand();
    	}
    
    	public void Undo()
    	{
    		Execute(() => { if (stack.Count > 0) total = stack.Pop(); }, undoable: false);
    	}
    
    	private void Execute(Action command, bool undoable = true)
    	{
    		var oldValue = total;
    		command();
    		lastCommand = command;
    		if (undoable) stack.Push(oldValue);
    	}
    }
