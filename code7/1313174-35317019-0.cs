    // Gets the folder path in which your .exe is located
    var parentFolder = Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location);
    // Makes the absolute path
    var absolutePath = Path.Combine(parentFolder, "\BuildDLLs\myDLL.dll");
    // Load the DLL using the absolute path
    var DLL = Assembly.LoadFile(absolutePath);
