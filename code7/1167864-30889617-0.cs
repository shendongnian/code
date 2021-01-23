    object obj = "Int32";
    string str1 = typeof(int).Name;
    string str2 = typeof(int).Name;
    Console.WriteLine(obj == str1); // false
    Console.WriteLine(str1 == str2); // true
    Console.WriteLine(obj == str2); // false !?
