    var uc1 = new UserComponent { Count = 1 };
    var uc2 = new UserComponent { Count = 2 };
    var uc3 = new UserComponent { Count = 2 };
    var u1 = new User();
    var u2 = new User();
    u1.UserComponents.Add(uc1);
    u1.UserComponents.Add(uc2);
    u2.UserComponents.Add(uc1);
    u2.UserComponents.Add(uc3);
    Console.Write(u1.UserComponents[0].Count); //Outputs 1
    Console.Write(u1.UserComponents[1].Count); //Outputs 2
    Console.Write(u2.UserComponents[0].Count); //Outputs 1
    Console.Write(u2.UserComponents[1].Count); //Outputs 2
    u2.UserComponents[0].Count = 5;
    u2.UserComponents[1].Count = 6;
    Console.Write(u1.UserComponents[0].Count); //Outputs 5
    Console.Write(u1.UserComponents[1].Count); //Outputs 6
    Console.Write(u2.UserComponents[0].Count); //Outputs 5
    Console.Write(u2.UserComponents[1].Count); //Outputs 2
