    void Main()
    {
       IStuff s = new MyStuff<int>();
       Console.WriteLine(s.DoSomethingWith(2.34)); // compare will be false (double != int)
       Console.WriteLine(s.DoSomethingWith(5)); // compare will be true (int == int)
    }
    // Define other methods and classes here
    public interface IStuff
    {
        bool DoSomethingWith<T2>(T2 type);
    }
    public class MyStuff<T> : IStuff
    {
       public MyStuff()
       {
          // Do whatever with type T
       }
       public bool DoSomethingWith<T2>(T2 type)
       {
          // dummy code here that returns a bool
          Type theType = typeof(T2);
          return theType == typeof(T);
       }
    }
