            using (RSACryptoServiceProvider RSA = new RSACryptoServiceProvider(1024))
            {
                var serializer = new XmlSerializer(typeof (RSAParameters));
                var privateAndPublicKey = RSA.ExportParameters(true);
                var publicKeyOnly = RSA.ExportParameters(false);
                // Saving keys
                using (var fileStream = File.OpenWrite(@"C:\temp\PrivateAndPublic.xml"))
                    serializer.Serialize(fileStream, privateAndPublicKey);
                using (var fileStream = File.OpenWrite(@"C:\temp\publicKeyOnly.xml"))
                    serializer.Serialize(fileStream, publicKeyOnly);
                // Restoring keys
                using (var fileStream = File.OpenRead(@"C:\temp\PrivateAndPublic.xml"))
                    privateAndPublicKey = (RSAParameters)serializer.Deserialize(fileStream);
                using (var fileStream = File.OpenRead(@"C:\temp\publicKeyOnly.xml"))
                    publicKeyOnly = (RSAParameters) serializer.Deserialize(fileStream);
                RSA.ImportParameters(privateAndPublicKey);
                RSA.ImportParameters(publicKeyOnly );
            }
