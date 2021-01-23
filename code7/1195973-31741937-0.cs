    static void ExtractPublicKeyFromPem(string path)
        {
            var startText = "-----BEGIN PUBLIC KEY-----";
            var endText = "-----END PUBLIC KEY-----";
            var pem = System.IO.File.ReadAllText(path);
            var start = pem.LastIndexOf(startText);
            var end = pem.IndexOf(endText);
            var publicKey = pem.Substring(start, end - start);
        }
