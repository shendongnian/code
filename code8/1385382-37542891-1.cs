    using System.IO;
    ...
    
    if (!string.IsNullOrEmpty(_location.FolderName))
    {
        name = Path.Combine(_location.FolderName, name);
    }
