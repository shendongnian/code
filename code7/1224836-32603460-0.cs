    if(Directory.Exist(path))
    {
        try
        {
            string[] subdirs = Directory.GetDirectories(path);
        }
        catch (Exception ex)
        {
        }
    }
