    using System;
    
    namespace ConsoleApplication1 {
        public class Program { 
            public static void Main() {
                var s1 = "String1";
                var s2 = "String2";
                var s3 = (string)null;
    
                Console.WriteLine((from u in s1
                                   from v in s2
                                   select u + " " + v) ?? "Nothing");
    
                Console.WriteLine((from u in s1
                                   from v in s3
                                   select u + " " + v) ?? "Nothing");
                Console.ReadLine();
            }
        }
    
        public static class Extensions {
            public static TResult Select<TValue, TResult>(this
                TValue @this,
                Func<TValue, TResult> projector
            ) where TValue : class where TResult : class {
                return @this==null ? null : projector(@this);
            }
    
            public static TResult SelectMany<TValue, T, TResult>(this
                TValue @this,
                Func<TValue, T> selector,
                Func<TValue, T, TResult> resultSelector
            ) where TValue : class where TResult : class where T : class {
                return @this==null ? null : selector(@this).Select(e => resultSelector(@this, e)); ;
            }
        }
    }
