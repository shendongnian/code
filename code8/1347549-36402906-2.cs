    using AppKit;
    using System.IO;
    ...
    string data = "Some data";
    string filename = "Some filename";
    File.WriteAllText (filename, data);
    NSWorkspace.SharedWorkspace.OpenFile (filename, "Graphviz");
