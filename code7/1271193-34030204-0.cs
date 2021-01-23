    List1 = new List<Fake>() {new Fake { MyVal = "hello" } };
    List2 = new List<Fake>(List1);
    
    List2.Add(new Fake { MyVal = "hey" });
    Console.WriteLine(List1.Length); // 1
    Console.WriteLine(List2.Length); // 2
    List2[0].MyVal = "hi";
    Console.WriteLine(List1[0].MyVal) // hi
    
