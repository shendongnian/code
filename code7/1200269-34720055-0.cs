    try
    {
        // Maybe some sa-exception occurse
    }
    catch (Exception ex)
    {
        if (ex is iAnywhere.Data.SQLAnywhere.SAException)
        {
            var saException = (iAnywhere.Data.SQLAnywhere.SAException)ex;
            // Only catch table locks
            if (saException.NativeError == -210 || saException.ErrorCode == -210
                 || saException.NativeError == -1281 || saException.ErrorCode == -1281)
            {
                // Table lock here!
            }
        }
        else { // do some thing else... }
    }
