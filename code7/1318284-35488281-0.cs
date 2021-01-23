    try
    {
        FileStream oStream;
        StreamWriter sWriter;
        var oldOut = Console.Out;
        var desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        const string outputFileName = "\\errorlog.txt";
        var fullPath = string.Concat(desktopPath, outputFileName);
        Console.SetOut(sWriter);
        foreach (DirectoryInfo dir in directories)
        {
           try
           {
               dir.Delete(true);
           }
           catch(System.IO.IOException msg)
           {
               code = 5;
               errorLog.Add(String.Concat(dir.FullName," ",msg.Message));
               Console.WriteLine("Error Removing the directory: {0}", dir.FullName);
           }
        }
    }
    catch(Exception e)
    {
        //handle error with streams or file
    }
    finally
    {
        //ensures that we close the connections and such
        Console.SetOut(oldOut);
        sWriter.Close();
        oStream.Close();
    }
