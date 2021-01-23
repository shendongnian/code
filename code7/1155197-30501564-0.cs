             string logRequest = string.Empty;
             using (StreamReader reader = new StreamReader(request.InputStream))
                {
                    try
                    {
                        request.InputStream.Position = 0;
                        logRequest = reader.ReadToEnd();
                    }
                    catch (Exception ex)
                    {
                        logRequest  = string.Empty;
                       //log errors
                    }
                    finally
                    {
                        request.InputStream.Position = 0;
                    }
    
                }
