    public struct MyStruct
    {
    }
    class Test
    {
        public Test()
        {
            var ms = new MyStruct();
            var ms2 = ms;
            ms3 = ms;
            ms = ms3;
            ms4 = ms;
            ms = ms4;
            ms4 = ms4;
            new MyObject(default(MyStruct));
        }
        public MyStruct ms3;
        public MyStruct ms4 { get; set; }
    }
    public class MyObject
    {
        public MyObject(MyStruct par1)
        {
        }
    }
