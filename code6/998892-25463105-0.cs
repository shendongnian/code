    var destPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "StackOverflow");
    var picPath = Path.Combine(destPath, "pic.jpg");
            
    if (!Directory.Exists(destPath))
    {
        Directory.CreateDirectory(destPath);
    }
    var bitmap = new Bitmap(Properties.Resources.pptfooter);
    bitmap.Save(picPath);
    Process.Start(picPath);
