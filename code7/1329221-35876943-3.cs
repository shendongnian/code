    class Test
    {
        public static int Add(int x, int y) => x + y;
    }
    var addOne = par(Test.Add, 1);
    var r = addOne(2);
