    A a = new A();
    B b = new B();
    a.Numbers.Add(b.Result);
    Console.WriteLine(a.Numbers.Last());
    b.Result.Value = 50;
    Console.WriteLine(a.Numbers.Last());
