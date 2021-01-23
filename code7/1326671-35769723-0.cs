    string value = "\\Examp\"l'e";
    string[] replaceAll = {"\\","\"", "'"};
    foreach(string str in replaceAll)
        value = value.Replace(str, ""); 
    Console.Write(value); // Example
