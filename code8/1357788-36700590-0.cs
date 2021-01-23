    using System.Text;
    using PCLCrypto;
    
    public static string hash_hmacSha1(string data, string key) {
    	byte[] keyBytes = Encoding.UTF8.GetBytes(key);
    	byte[] dataBytes = Encoding.UTF8.GetBytes(data);
    	var algorithm = WinRTCrypto.MacAlgorithmProvider.OpenAlgorithm(MacAlgorithm.HmacSha1);
    	CryptographicHash hasher = algorithm.CreateHash(keyBytes);
    	hasher.Append(dataBytes);
    	byte[] mac = hasher.GetValueAndReset();
    
    	StringBuilder sBuilder = new StringBuilder();
    	for (int i = 0; i < mac.Length; i++) {
    		sBuilder.Append(mac[i].ToString("X2"));
    	}
    	return sBuilder.ToString().ToLower();
    }
.
    string data = "WhatIsYourNumber";
    string secretKey = "AliceAndBob";
    System.Diagnostics.Debug.WriteLine("{0}", Utils.hash_hmacSha1(data, secretKey));
