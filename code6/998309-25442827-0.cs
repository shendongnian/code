    string a = "123";
    char c = a[a.Length - 1];
    string c2 = string.Concat(c,c);
    int v = Int32.Parse(c.ToString());
    int v2 = v + v;
    Console.WriteLine("This is a char:" + c);   // 3
    Console.WriteLine("This is a string:" + c2); // 33
    Console.WriteLine("This is an integer: " + v);  // 3
    Console.WriteLine("This is an integer: " + v2);  // 6
