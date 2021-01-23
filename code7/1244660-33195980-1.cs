    // In C# a struct is a value type
    public struct A 
    {
        public string Text;
    
        public A(string text) 
        {
            Text = text;
        }
    }
    
    A a = new A("hello world");
    
    // This creates a copy, instead of assigning the same "object" to a new reference
    A a1 = a; 
