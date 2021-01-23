    // Place this at the top of the file
    using System.IO;
    ...
    // Whatever you want to save.
    var contents = "file contents";
    // The app roaming path for your game directory.
    var folder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "game");
    // Creates the directory if it doesn't exist.
    Directory.CreateDirectory(folder);
    // The name of the file you want to save your contents in.
    var file = Path.Combine(folder, "data.xml");
    // Write the contents to the file.
    File.WriteAllText(file, contents);
