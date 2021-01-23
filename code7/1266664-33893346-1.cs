    using System;
    using System.Runtime.ExceptionServices;
              
    public class Program
    {
      public static void Main()
      {
          AppDomain.CurrentDomain.FirstChanceException += 
          (object source, FirstChanceExceptionEventArgs e) =>
          {
            Console.WriteLine("FirstChanceException event raised in {0}: {1}",
              AppDomain.CurrentDomain.FriendlyName, e.Exception.Message);
          };
        Console.WriteLine("Hello World");
        Console.WriteLine(DoSomethingWithLogging(() => Foo()));
      }
      
      public static TResult DoSomethingWithLogging<TResult>(Func<TResult> someAction)
      {
        try
        {
          return someAction.Invoke();
        }
        catch (Exception ex)
        {
          Console.WriteLine(ex.Message);
          throw;
        }
      }
      
      public static string Foo()
      {
        try
        {
          throw new Exception("This will be caught");
          return"Foo";
        }
        catch (Exception) //I have to log this exception too without adding anything too Foo
        {
          return "Exception caught";      
        }    
      }
    }
