    using System;
    
    public interface ITest
    {
      void TestMethod();
    }
    
    public class Test : ITest
    {
      void ITest.TestMethod()
      {
        Console.WriteLine("I am Test");
      }
    
      void TestMethod()
      {
        Console.WriteLine("I am other test");
      }
    }
