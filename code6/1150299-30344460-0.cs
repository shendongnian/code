    abstract class ABase { }
    class A1 : ABase { }
    class A2 : ABase { }
    
    public abstract class FactoryBBase
    {
        public abstract IProcessor Create(ABase a);
    }
    public class ConcreteFactory : FactoryBBase
    {
        override public IProcessor Create(ABase a)
        {
            // this is ugly for a large amount of ABase implementations of course
            if (a is A1)
    		{
    			return new Runtime1();
    		}
    		if (a is A2)
    		{
    			return new Runtime2();
    		}
    		throw new NotSupportedException();
        }
    }
    
    public interface IProcessor
    {
    	void ProcessA(ABase a);
    }
    
    public class Runtime1
    {
        public void ProcessA(ABase a)
        {
            // process away
        }
    }
    
    public class Runtime2
    {
        public void ProcessA(ABase a)
        {
            // process away differently
        }
    }
