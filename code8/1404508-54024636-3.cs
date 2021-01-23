    private static X509Certificate2 GetClientCertificate(string clientCertName, string password)
    {
        //Create X509Certificate2 object from .pfx file
    	byte[] rawData = null;
    	using (var f = new FileStream(Path.Combine(AppContext.BaseDirectory, clientCertName), FileMode.Open, FileAccess.Read))
        {
            var size = (int)f.Length;
            var rawData = new byte[size];
            f.Read(rawData, 0, size);
            f.Close();
        }
        return new X509Certificate2(rawData, password);
    }
