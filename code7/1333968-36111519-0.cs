    using Org.BouncyCastle.Crypto.Parameters;
    using Org.BouncyCastle.Security;
    private byte[] Decrypt(byte[] content, byte[] key, byte[] iv, string mode)
            {
    
                var cipher = CipherUtilities.GetCipher(mode);
                cipher.Init(false, new ParametersWithIV(new KeyParameter(key), iv));
                var blockBytes = cipher.ProcessBytes(content, 0, content.Length);
                var finalBytes = cipher.DoFinal();
    
                var plainBytes = new byte[content.Length];
    
                var counter = 0;
                if (blockBytes != null)
                {
                    for (var i = 0; i < blockBytes.Length; i++)
                        plainBytes[counter++] = blockBytes[i];
                }
    
                if (finalBytes != null)
                {
                    for (var i = 0; i < finalBytes.Length; i++)
                        plainBytes[counter++] = finalBytes[i];
                }
    
                return plainBytes;
            }
