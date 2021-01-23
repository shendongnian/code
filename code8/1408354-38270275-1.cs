    var foo = new AwesomeItemSpecial1();
    foo.A = 42;
    foo.B = -1;
    var bar = new AwesomeItemSpecial2();
    bar.A = 3;
    bar.B = 59;
    var awesomeList = new List<AwesomeItemBase>();
    awesomeList.Add(foo);
    awesomeList.Add(bar);
    foreach (var item in awesomeList) {
        Console.WriteLine("A = {0}, B = {1}", item.A, item.B);
    }
    // output is:
    // A = 42, B = -1
    // A = 3, B = 59
