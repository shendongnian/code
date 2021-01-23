    // here you could replace "YourApplicationName" with any name you want, but
    // name it after your application is a better convension
    var destPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "YourApplicationName");
    var picPath = Path.Combine(destPath, "pic.jpg");
            
    if (!Directory.Exists(destPath))
    {
        Directory.CreateDirectory(destPath);
    }
    var bitmap = new Bitmap(Properties.Resources.dust2);
    bitmap.Save(picPath);
    Process.Start(picPath);
