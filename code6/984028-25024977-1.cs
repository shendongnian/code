    using (StreamWriter writer = new StreamWriter(appStartMenuPath + ".url"))
    {
        writer.WriteLine("[InternetShortcut]");
        writer.WriteLine("URL=file:///" + pathToExe);
        writer.WriteLine("IconIndex=0");
        string icon = pathToExe.Replace('\\', '/');
        writer.WriteLine("IconFile=" + icon);
    }
