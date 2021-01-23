    byte[] result;
    using (var webClient = new System.Net.WebClient())
    {
    	result = webClient.DownloadData("http://some.url");
    }
    
    byte[] hash = ((HashAlgorithm)CryptoConfig.CreateFromName("MD5")).ComputeHash(result);
