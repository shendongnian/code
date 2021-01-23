    string foo = "Fix value?"; //New address: 0x02b215f8
    string foo2 = "Fix value?"; //Points to same address: 0x02b215f8
    string fooCopy = string.Copy(foo); //New address: 0x021b2888
    fixed (char* p = foo)
    {
        p[9] = '!';
    }
    Console.WriteLine(foo);
    Console.WriteLine(foo2);
    Console.WriteLine(fooCopy);
    //Reference is equal, which means refering to same memory address
    Console.WriteLine(string.ReferenceEquals(foo, foo2)); //true
    //Reference is not equal, which creates another string in new memory address
    Console.WriteLine(string.ReferenceEquals(foo, fooCopy)); //false
