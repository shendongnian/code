    // J:\ is an unused drive letter
    var xDummy1 = new System.IO.DriveInfo("J:\\");
    Console.WriteLine(xDummy1.Name);                        // result: J:\
    Console.WriteLine(xDummy1.DriveType);                   // result: NoRootDirectory 
    Console.WriteLine(xDummy1.IsReady);                     // result: False 
    // Console.WriteLine(xDummy1.DriveFormat); // would throw an DriveNotFoundException
    Console.WriteLine(System.IO.Directory.Exists("j:\\"));  // result: False
    // S:\ is an mapped drive to a currently not available share
    var xDummy2 = new System.IO.DriveInfo("S:\\");          
    Console.WriteLine(xDummy2.Name);                        // result: S:\ 
    Console.WriteLine(xDummy2.DriveType);                   // result: Network
    Console.WriteLine(xDummy2.IsReady);                     // result: False 
    // Console.WriteLine(xDummy2.DriveFormat); // would throw an IOException
    Console.WriteLine(System.IO.Directory.Exists("S:\\"));  // result: False
