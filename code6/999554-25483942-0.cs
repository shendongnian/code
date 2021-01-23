    public class SomeClass
    {
        public string  str= string.Empty;
    
        private class SomePrivateClass
        {
             public void DoSomething()
             {
    
             }
        }
        public void CreateObjectOfSomePrivateClass()
        {
            SomePrivateClass obj = new SomePrivateClass();
            obj.DoSomething();
        }
    }
