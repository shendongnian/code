    public static string EncryptUsingAes(byte[] inputTextByte, byte[] privateKeyByte, byte[] sharedIVKeyByte)
            {
                using (var aesEncryption = AesEncryption.AesEncryptionType(privateKeyByte, sharedIVKeyByte))
                {
                    // Convert string to byte array                
                    byte[] dest = new byte[inputTextByte.Length];
    
                    // encryption
                    using (ICryptoTransform encrypt = aesEncryption.CreateEncryptor(aesEncryption.Key, aesEncryption.IV))
                    {
                        dest = encrypt.TransformFinalBlock(inputTextByte, 0, inputTextByte.Length);
    
                        encrypt.Dispose();                        
                    }
                    return BitConverter.ToString(dest).Replace("-", "");
                }
            }
    public static string DecryptUsingAes(byte[] inputTextByte, byte[] privateKeyByte, byte[] sharedIVKeyByte)
            {
                using (var aesDecryption = AesEncryption.AesEncryptionType(privateKeyByte, sharedIVKeyByte))
                {
                    // Convert string to byte array                
                    byte[] dest = new byte[inputTextByte.Length];
    
                    // encryption
                    using (ICryptoTransform decrypt = aesDecryption.CreateDecryptor(aesDecryption.Key, aesDecryption.IV))
                    {
                        dest = decrypt.TransformFinalBlock(inputTextByte, 0, inputTextByte.Length);
    
                        decrypt.Dispose();
                        
                    }
                    // Convert byte array to UTF8 string
                    return Encoding.UTF8.GetString(dest); ;
                }
            }
