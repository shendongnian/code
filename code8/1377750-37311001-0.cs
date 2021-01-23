    public interface ITest
    {
        string Speak();
    }
    
    public class ParentTest : ITest
    {
        string ITest.Speak()
        {
            return Speak();
        }
    	
    	protected virtual string Speak()
    	{
    	    return "Meow";
    	}
    
    }
    
    public class ChildTest : ParentTest
    {
    	protected override string Speak()
        {
            return "Mooo";
        }
    }
