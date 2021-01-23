    class Test
    {
        public static readonly int Add(int x, int y) => x + y;
    }
    var add = curry(Test.Add);
    var r = add(1)(2);
