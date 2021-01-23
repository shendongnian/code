    using System.Collections.Specialized;
    ...
    ...
    //Copy the Filename to Clipboard
    StringCollection collection = new StringCollection();
    collection.Add(Environment.CurrentDirectory + "\\MyFile.zip");
    //Paste into the selected Range.
    range.Paste();
