    class Program
    {
        public static void Main (string[] args)
        {
    
            Lua lua = new Lua();
            lua.LoadCLRPackage();
    
            lua.DoString(@"
                            import ('LuaTest', 'LuaTest')
                            test = Test()
                        ");
        }
    }
    
    public class Test
    {
        public Test()
        {
            Console.WriteLine("IT WORKED");
        }
    }
