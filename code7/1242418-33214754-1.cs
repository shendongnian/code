    using System.Collections.Specialized;
    ...
    ...
    //Copy the Filename to Clipboard (setFile function uses StringCollection)
    StringCollection collection = new StringCollection();
    collection.Add(Environment.CurrentDirectory + "\\MyFile.zip");
    Clipboard.SetFileDropList(collection);
    //Paste into the selected Range.
    range.Paste();
