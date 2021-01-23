    class Program
    {
        static object Create(string Name, params object[] Args)
        {
            Type theType = Type.GetType(Name);
            object toReturn = null;
            // Code wrote quickly, I just try to call all the type constructors...
            foreach (var constructor in Type.GetType(Name).GetConstructors())
            {
                try
                {
                    string paramPrefix = "p";
                    int pIdx = 0;
                    var expParamsConsts = new List<Expression>();
                    var ctrParams = constructor.GetParameters();
                    for (int i = 0; i < constructor.GetParameters().Length; i++)
                    {
                        var param = ctrParams[i];
                        var tmpParam = Expression.Variable(param.ParameterType, paramPrefix + pIdx++);
                        var expConst = Expression.Convert(Expression.Constant(Args[i]), param.ParameterType);
                        expParamsConsts.Add(expConst);
                    }
                    // new Type(...);
                    var expConstructor = Expression.New(constructor, expParamsConsts);
                    // return new Type(...);
                    var expLblRetTarget = Expression.Label(theType);
                    var expReturn = Expression.Return(expLblRetTarget, expConstructor, theType);
                    var expLblRet = Expression.Label(expLblRetTarget, Expression.Default(theType));
                    // { return new Type(...); }
                    var expBlock = Expression.Block(expReturn, expLblRet);
                    // Build the expression and run it
                    var expFunc = Expression.Lambda<Func<dynamic>>(expBlock);
                    toReturn = expFunc.Compile().Invoke();
                }
                catch (Exception ex)
                {
                    ex.ToString();
                }
            }
            return toReturn;
        }
    
        static void Main(string[] args)
        {
            var tmpTestClass = Create(TYPE_NAME, 5);
            tmpTestClass = Create(TYPE_NAME, new ImplicitTest(5.1));
        }
    }
    
    public class ImplicitTest
    {
        public double Val { get; set; }
    
        public ImplicitTest(double Val)
        {
            this.Val = Val;
        }
    
        public static implicit operator int(ImplicitTest d)
        {
            return (int)d.Val;
        }
    }
    
    public class TestClass
    {
        public int Val { get; set; }
    
        public TestClass(int Val)
        {
            this.Val = Val;
        }
    }
