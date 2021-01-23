    var DeleteFromDir = new DirectoryInfo(sFromPath);
    var files = DeleteFromDir.GetFiles("*.txt");
    foreach (var file in files)
    {
        if (bDeletePermanently)
        {
            file.Delete();
        }
        else
        {
            FileSystem.DeleteFile(file.FullName, UIOption.OnlyErrorDialogs, RecycleOption.SendToRecycleBin);
        }
    }
