    public class MyClass
    {
        private static Dictionary<string, Dictionary<string, string>> myDictionary;
    
        static MyClass()
        {
            //Initialize static members here
            myDictionary = new Dictionary<string, Dictionary<string, string>>();
            myDictionary.Add("mykey", new Dictionary<string, string>());
            ...
        }
    }
 
