    private static void ProcessPostRequest(System.Net.HttpListenerContext context)
    {
        // Read the entire POST data into a byte array.  This isn't ideal.  Also, it does not supported 'chunked' encoding.
        byte[] input      = new byte[context.Request.ContentLength64];
        int    bytesRead  = 0;
        int    totalBytes = 0;
        while ((bytesRead = context.Request.InputStream.Read(input, totalBytes, Math.Min(4096, input.Length - totalBytes))) > 0)
        {
            totalBytes += bytesRead;
        }
        System.Diagnostics.Debug.WriteLine($"Read {totalBytes:#,##}");
        var cert = context.Request.GetClientCertificate();
        if (cert != null)
        {
            System.Diagnostics.Debug.WriteLine(cert.Subject);
        }
        // Be sure to write to or close the Response.
    }
