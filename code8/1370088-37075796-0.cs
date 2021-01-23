    foreach (FileInfo file in di.GetFiles())
    {
        try
        {
            file.Delete();
        }
        catch(Exception e)
        {
            // Log error.
        }
    }
