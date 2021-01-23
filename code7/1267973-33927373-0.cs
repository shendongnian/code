    var list1 = GetList1();
    Console.WriteLine(list1.Count); // 3
    var list2 = new List(list1);
    list2.Add(new AddressData("John Doe", "Foo street", "12345"); 
    Console.WriteLine(list1.Count); // 3
    Console.WriteLine(list2.Count); // 4
