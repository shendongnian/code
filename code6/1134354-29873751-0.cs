    class Program
    {
        public static void Main (string[] args)
        {
    
            Lua lua = new Lua();
            lua.LoadCLRPackage();
    
            lua.DoString(@"
                            import ('LuaTest.exe', 'LuaTest')
                            test = Test()
                        ");
        }
    }
    [TestFixture]
    public class Test
    {
        [Test]
        public Test()
        {
            Console.WriteLine("IT WORKED");
        }
    }
