    string str1 = "aaac", str2 = "b";
    Console.WriteLine(str1);
    Console.WriteLine(str2);
    str2 = str2 + str1;
    str1 = str2.Substring(0,str2.Length - str1.Length);
    str2 = str2.Substring(a.Length);
    Console.WriteLine("<" + str1 + ">");
    Console.WriteLine("<" + str2 + ">");
