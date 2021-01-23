    while (true)
    {
        Thread.Sleep(50);
        try
        {
            File.Delete(frompath);
            break;
        }
        catch (IOException)
        {
            // Ignore IO exceptions
        }
        catch (Exception)
        {
            // Handle other exceptions
        }
    }
