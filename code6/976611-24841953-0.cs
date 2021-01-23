    using System;
    using System.Diagnostics;
    using System.Linq.Expressions;
    
    namespace ExpressionTreeTest
    {
        class Program
        {
            static void Main()
            {
                Func<int, int, int> add1 = (a, b) => a + b;
                Func<int, int, int> add2 = AddMethod;
    
                var x = Expression.Parameter(typeof(int));
                var y = Expression.Parameter(typeof(int));
                var additionExpr = Expression.Add(x, y);
                var add3 = Expression.Lambda<Func<int, int, int>>(
                                  additionExpr, x, y).Compile();
    
    
                TimingTest(add1, "add1", 1000000);
                TimingTest(add2, "add2", 1000000);
                TimingTest(add3, "add3", 1000000);
            }
    
            private static void TimingTest(Func<int, int, int> addMethod, string testMethod, int numberOfAdditions)
            {
                var sw = new Stopwatch();
                for (var c = 0; c < numberOfAdditions; c++)
                {
                    sw.Start();
                    addMethod(1, 2);
                    sw.Stop();
                }
               Console.WriteLine("Total calculation time {1}: {0}", sw.Elapsed, testMethod);
            }
    
            private static int AddMethod(int a, int b)
            {
                return a + b;
            }
        }
    }
