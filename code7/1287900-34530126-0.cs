    public class Animal<TFingerType> where TFingerType : IFinger
    {
    	Hand<TFingerType> GetHand() 
    	{
            //... Do something
    	}
    }
    
    public class Monkey : Animal<MonkeyFinger> { }
    public class Hand<TFingerType> where TFingerType : IFinger
    {
    
    }
    public interface IFinger
    {
    
    }
    public class MonkeyFinger : IFinger {
    }
