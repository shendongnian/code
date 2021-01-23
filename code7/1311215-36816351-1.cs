    var path = System.IO.Path.Combine(Windows.Storage.ApplicationData.Current.LocalFolder.Path, App.DATABASE_NAME);
    var di = new DirectoryInfo(path);
    di.Attributes &= ~System.IO.FileAttributes.ReadOnly;
    di.Attributes &= ~System.IO.FileAttributes.Archive;
    di.Attributes &= ~System.IO.FileAttributes.Temporary;  
