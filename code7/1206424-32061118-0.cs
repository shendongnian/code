    class A
    {
        public string Member { get { return "A"; } }
    }
    
    class B : A
    {
        public new string Member { get { return "B"; } }
    }
    
    A realA = new A();
    B realB = new B();
    A fakeA = new B();
    
    Console.WriteLine(realA.Member); // Prints "A"
    Console.WriteLine(realB.Member); // Prints "B", Only way to print "B" is to be a B and not casted to anything (real B)
    Console.WriteLine(fakeA.Member); // Prints "A"
    Console.WriteLine((realB as A).Member); // Prints "A", here we won't see hidden members
