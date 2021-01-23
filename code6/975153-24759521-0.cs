    var splitOn = "App";
    var path = "//Hello//Products//App//Images//Room//40//Tulips.jpg";
    
    var parts = path.Split(new string[] { splitOn }, StringSplitOptions.None);
    Console.WriteLine(parts[0] + splitOn);
    Console.WriteLine(parts[1]);
