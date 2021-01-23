            var publicKey =
                           "<RSAKeyValue><Modulus>base64modulusgoeshere</Modulus><Exponent>AQAB</Exponent></RSAKeyValue>";
            var sbytes = Encoding.UTF8.GetBytes(s);
            var rsa = new RSACryptoServiceProvider(2048);
            rsa.FromXmlString(publicKey);
            var encdata = rsa.Encrypt(sbytes, false);
            enc = Convert.ToBase64String(encdata);
