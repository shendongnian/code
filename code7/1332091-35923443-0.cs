    string st1 = new string(bigString.Reverse().ToArray());    
    string[] st2 = st1.Split(new char[] { '.' }, 3);
    
    string user = new string(st2[0].Reverse().ToArray());
    string method = new string(st2[1].Reverse().ToArray());
    string msg = new string(st2[2].Reverse().ToArray());
    
    Console.WriteLine(user);
    Console.WriteLine(method);
    Console.WriteLine(msg);
