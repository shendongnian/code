    public abstract class Result { }
    
    public class ResultA : Result { }
    
    public class ResultB : Result { }
    
    public interface IKing<out T> where T : Result {}
    public abstract class King<T> : IKing<T> where T : Result
    {
        public abstract T Get();
    }
    
    public class KingA : King<ResultA>
    {
        public override ResultA Get()
        {
            return new ResultA();
        }
    }
    
    public class KingB : King<ResultB>
    {
        public override ResultB Get()
        {
            return new ResultB();
        }
    }
    
    public class TestClass
    {
        King<ResultA> a = new KingA(); // allowed by  public static implicit operator King<Result>(KingA v)
        King<ResultB> b = new KingB(); // allowed by  public static implicit operator King<Result>(KingB v)
        KingA ka = new KingA();
        List<IKing<Result>> lista = new List<IKing<Result>>();
    	
        public void Test()
        {
            lista.Add(ka);
        }        
    }
