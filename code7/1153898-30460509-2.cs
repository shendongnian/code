    public interface ICondition
    {
      bool IsTrue();
    }
    
    public class Condition<T> : ICondition
    {
      T _param1;
      T _param2;
      Func<T,T,bool> _predicate;
    
      public Condition<T>(T param1, T param2, Func<T,T,bool> predicate)
      {
        _param1 = param1;
        _param2 = param2;
        _predicate = predicate;
      }
      
      public bool IsTrue(){ return _predicate(_param1,_param2);}
    }
    
    public static void Test()
    {
      var x = 2;
      var y = 5;
      var foo = "foo";
      var bar = "bar";     
      var conditions = new List<ICondition>
      {
        new Condition(x,y, (x,y) => y % x == 0),
        new Condition(foo,bar, (f,b) => f.Length == b.Length)
      }
      
      foreach(var condition in conditions)
      {
        Console.WriteLine(condition.IsTrue());
      }
    }
      
