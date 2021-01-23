    using System.IO;
    ....
    string description = "This is my description link with <invalid characters>";
    char[] invalidChars = Path.GetInvalidFileNameChars();
    
    foreach (var c in invalidChars )
    {
        description = description.Replace(c.ToString(), ""); 
    }
