    public class Condition<T>
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
      public bool IsTrue(){ return predicate(_param1,_param2);}
    }
    
    public static voi Test()
    {
      var x = 2;
      var y = 5;
      var condition = new Condition(x,y, (x,y) => y % x == 0);
      Console.WriteLine(condition.IsTrue());
    }
      
