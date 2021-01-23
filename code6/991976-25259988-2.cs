    public struct A
    {
        public string S;
    }
    
    A a;
    A b;
    a.S = "Hello";
    b.S = "Hello world".Split(' ')[0]; //to avoid reusing the same reference, probably ;]
    var result = (a == b);
