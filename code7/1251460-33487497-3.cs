    private static void Main(string[] args)
            {
                //Use the values from Oracle
                string inputText = "Test";
                string encryptionType = "AES256";
                string encryptPrivateKey = "12345678901234567890123456789012";
                string encryptSharedIV = "26744a68b53dd87a";//26744a68b53dd87a26744a68b53dd87a";
                string encryptedTextValue = "E320A0CABF881088A424B4F36F188029";
    
                Console.WriteLine("******************** Initial values from Oracle ******************");
                Console.WriteLine("inputText: '{0}'", inputText);
                Console.WriteLine("encryptionType: '{0}'", encryptionType);
                Console.WriteLine("encryptedTextValue: '{0}'", encryptedTextValue);
                Console.WriteLine("encryptPrivateKey: '{0}'", encryptPrivateKey);
                Console.WriteLine("encryptSharedIV: '{0}'", encryptSharedIV);
    
                //OracleRaw
                string oracleRawText = "54657374";
                string oracleRawPrivateKey = "3132333435363738393031323334353637383930313233343536373839303132";
                string oracleRawSharedIV = "32363734346136386235336464383761"; //26744a68b53dd87a - IV is 16 byte array.            
    
                Console.WriteLine("******************** Initial values from Oracle OracleRaw ******************");
                Console.WriteLine("oracleRawText: '{0}'", oracleRawText);
                Console.WriteLine("oracleRawPrivateKey: '{0}'", oracleRawPrivateKey);
                Console.WriteLine("oracleRawSharedIV: '{0}'", oracleRawSharedIV);
                Console.WriteLine();
    
                //This is just here to convert the Encrypted byte array to a string for viewing purposes.
                var utf = new UTF8Encoding();
                byte[] inputTextByte = utf.GetBytes(inputText); //byte: 4 - "Test"
                byte[] privateKeyByte = utf.GetBytes(encryptPrivateKey); //byte: 32 - "12345678901234567890123456789012"
                byte[] sharedIVByte = utf.GetBytes(encryptSharedIV); //byte: 16 - "26744a68b53dd87a"
    
                //string Decrypted;
                try
                {
                    string encryptedText = string.Empty;
    
                    byte[] oracleRawTextByte = StringToByteArray(oracleRawText);
                    byte[] oracleRawPrivateKeyByte = StringToByteArray(oracleRawPrivateKey);
                    byte[] oracleRawSharedIVByte = StringToByteArray(oracleRawSharedIV);
    
                    encryptedText = EncryptUsingAes(oracleRawTextByte, oracleRawPrivateKeyByte, oracleRawSharedIVByte);
                    Console.WriteLine("********************Encryption Example EncryptUsingAes(OracleRaw) ******************");
                    Console.WriteLine("Plain text is: '{0}'", inputText);
                    Console.WriteLine("Encrypted text is: '{0}'", encryptedText);
                    Console.WriteLine();
    
                    encryptedText = EncryptUsingAes(inputTextByte, privateKeyByte, sharedIVByte);
                    Console.WriteLine("********************Encryption Example EncryptUsingAes******************");
                    Console.WriteLine("Plain text is: '{0}'", inputText);
                    Console.WriteLine("Encrypted text is: '{0}'", encryptedText);
                    Console.WriteLine();
    
                    Console.WriteLine("********************Encryption Example DecryptUsingAes******************");
                    Console.WriteLine("Encrypted text is: '{0}'", encryptedText);
    
                    byte[] cypherText = StringToByteArray(encryptedText);
    
                    encryptedText = DecryptUsingAes(cypherText, privateKeyByte, sharedIVByte);
    
                    Console.WriteLine("Plain text is: '{0}'", encryptedText);
                    Console.WriteLine();                    
                }
                catch (Exception e)
                {
                    Console.WriteLine("Exception: {0}", e.Message);
                }
    
                Console.WriteLine("Press enter to exit");
                Console.ReadLine();
            }
        }
