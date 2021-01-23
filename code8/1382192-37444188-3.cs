    var list = new List<MutableStruct>();
    list.Add(new MutableStruct());
    Console.WriteLine(list[0].Value);
    list[0].MutableMethod();
    Console.WriteLine(list[0].Value);
    var x = list[0];
    x.MutableMethod();
    list[0] = x;
    Console.WriteLine(list[0].Value);
