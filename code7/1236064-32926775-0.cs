    // get location where application data director is located
    var appData = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
    
    // create dir if it doesnt exist
    var folder = System.IO.Path.Combine(appData, "SomeDir");
    System.IO.Directory.CreateDirectory(folder);
    // write something to the file
    var file = System.IO.Path.Combine(folder, "test.txt");
    System.IO.File.AppendAllText(file,"Foo");
