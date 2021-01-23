    public interface IBaseGame<out T> where T : BaseQuestion
    {
    }
    
    public class BaseGame<T> : IBaseGame<T>
    	where T : BaseQuestion
    {
    }
    
    public class BaseQuestion 
    {
    }
    
    public class Question : BaseQuestion
    {
    }
    
    public class SampleGame : BaseGame<Question>
    {
    }
