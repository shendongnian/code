    using System;
    using System.Linq.Expressions;
    
    namespace Bug461
    {
      class Program
      {
        enum Test { }
    
        static void Main()
        {
          Expression<Func<Test?, bool>> x = t => t == (Test?)null;
        }
      }
    }
