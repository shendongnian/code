    int flag;
    {
        StreamReader reader = new StreamReader(FileName, Encoding.GetEncoding("iso-8859-1"), true);
        try
        {
            flag = 1;
            // Some computing code
        }
        finally
        {
            if (reader != null) ((IDisposable)reader).Dispose();
        }
    }
    if (flag == 1)
    {
        // Some other code
    }
