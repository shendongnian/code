        static BenchmarkLambdaSimple()
        {
            addLambda = (a, b) => a + b;
            addLambdaConst = AddMethod;
            var x = Expression.Parameter(typeof(int));
            var y = Expression.Parameter(typeof(int));
            var additionExpr = Expression.Add(x, y);
            addBuilded =
                          Expression.Lambda<Func<int, int, int>>(
                              additionExpr, x, y).Compile();
        }
        static Func<int, int, int> addLambda;
        static Func<int, int, int> addLambdaConst;
        static Func<int, int, int> addBuilded;
        private static int AddMethod(int a, int b)
        {
            return a + b;
        }
        [Benchmark]
        public int AddBuilded()
        {
            return addBuilded(1, 2);
        }
        [Benchmark]
        public int AddLambda()
        {
            return addLambda(1, 2);
        }
        [Benchmark]
        public int AddLambdaConst()
        {
            return addLambdaConst(1, 2);
        }
