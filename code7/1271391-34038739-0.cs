    public abstract class IMockMe
    {
        private readonly string _a;
        private readonly string _b;
        public IMockMe()
        {
            
        }
        public IMockMe(string a, string b)
        {
            _a = a;
            _b = b;
        }
        public override string ToString()
        {
            return _a + " " + _b;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var mock = GetMock(typeof(IMockMe));
            Console.WriteLine(mock);
            var func = GetMock(typeof(Func<string, string, IMockMe>));
            Console.WriteLine(func);
            var del = (Delegate)func;
            mock = del.DynamicInvoke("try", "me");
            Console.WriteLine(mock);
            new Mock<IMockMe>();
            Console.ReadLine();
        }
        private static readonly Regex FuncRegex = new Regex(@"^System.Func`\d+$");
        public static object GetMock(Type type)
        {
            var mt = typeof(Mock<>);
            if (type.IsGenericType && FuncRegex.IsMatch(type.GetGenericTypeDefinition().FullName))
            {
                var args = type.GetGenericArguments();
                var returnType = args.Last();
                mt = mt.MakeGenericType(returnType);
                args = args.Take(args.Length - 1).ToArray();
                var parameters = new List<ParameterExpression>();
                for (var i = 0; i < args.Length; i++)
                {
                    var name = "P" + i;
                    var arg = args[i];
                    parameters.Add(Expression.Parameter(arg, name));
                }
                var array = Expression.NewArrayInit(typeof(object), parameters.Select(x => (Expression)x).ToArray());
                var ci = mt.GetConstructor(new[] {typeof (object[])});
                var constructor = Expression.New(ci, array);
                var methods = typeof(Expression).GetMethods();
                var method = (from m in methods
                              where m.Name == "Lambda"
                              let ps = m.GetParameters()
                              where ps.Length == 2
                              where ps[0].ParameterType == typeof(Expression)
                              where ps[1].ParameterType == typeof(ParameterExpression[])
                              select m)
                                  .First();
                var funcType = GetFuncType(mt, args);
                method = method.MakeGenericMethod(funcType);
                var expression = (Expression)method.Invoke(null, new object[] { constructor, parameters.ToArray() });
                var compile = expression.GetType().GetMethod("Compile");
                return compile.Invoke(expression, new object[0]);
            }
            
            mt = mt.MakeGenericType(type);
            return (Mock) Activator.CreateInstance(mt);
        }
        private static Type GetFuncType(Type mt, Type[] args)
        {
            Type result;
            switch (args.Length)
            {
                case 0:
                    result = typeof(Func<>);
                    break;
                case 1:
                    result = typeof(Func<,>);
                    break;
                case 2:
                    result = typeof(Func<,,>);
                    break;
                case 3:
                    result = typeof(Func<,,,>);
                    break;
                case 4:
                    result = typeof(Func<,,,,>);
                    break;
                case 5:
                    result = typeof(Func<,,,,,>);
                    break;
                default: throw new ArgumentOutOfRangeException("args");
            }
            var list = args.ToList();
            list.Add(mt);
            return result.MakeGenericType(list.ToArray());
        }
    }
