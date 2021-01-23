            //easy way
            Expression<Action<int>> printExpr = (arg) => Console.WriteLine(arg);
            printExpr.Compile()(10);
            //hard way
            ParameterExpression param = Expression.Parameter(typeof(int), "arg");
            MethodCallExpression methodCall = Expression.Call
                (
                      typeof(Console).GetMethod("WriteLine", new[]
                      {
                          typeof(int)
                      }
                 ),
                 param
              );
            Expression.Lambda<Action<int>>(methodCall, param).Compile()(10); //execution
