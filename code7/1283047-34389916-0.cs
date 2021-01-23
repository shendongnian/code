    public class VariablesDecleration : CodeTree
    {
    	//Impl
    	public void SomeStuff()
    	{
    		//... specific to Variables
    	}
    }
    
    public class LoopsDecleration : CodeTree
    {
    	//Impl
    	public void SomeStuff()
    	{
    		//... specific to Loops
    	}
    }
    
    public class CodeTree : ICodeTree
    {
    	void SomeStuff();
    }
    
    foreach (CodeTree code in tree.Codes)
    {
    	code.SomeStuff();
    }
