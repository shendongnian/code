    class Program
    {
        static void Main(string[] args)
        {            
            var array = new string[] { "str1", "str2" };
            SomeMethod(array);
            var list = new List<string> { "str1", "str2" };
            SomeMethod(list);                        
        }
    
        static void SomeMethod(IEnumerable<string> list)
        {
            //do stuff
        }
    }
