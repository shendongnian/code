    public void EncryptFile(string source, string destination)
            {
                string sKey = "super545";
                FileStream fsInput = new FileStream(source,
                    FileMode.Open,
                    FileAccess.Read);
    
                FileStream fsEncrypted = new FileStream(destination,
                                FileMode.Create,
                                FileAccess.Write);
    
                DESCryptoServiceProvider DES = new DESCryptoServiceProvider();// BAAAAAAAD IDEA - DES is dead...
                DES.Key = ASCIIEncoding.ASCII.GetBytes(sKey); // BAAAAAAAD IDEA - use some key derivation function like pbkdf2
                DES.IV = ASCIIEncoding.ASCII.GetBytes(sKey); // BAAAAAAAD IDEA - should be random, may be fixed ONLY for testing purposes
                ICryptoTransform desencrypt = DES.CreateEncryptor();
                CryptoStream cryptostream = new CryptoStream(fsEncrypted,
                                    desencrypt,
                                    CryptoStreamMode.Write);
                //byte[] bytearrayinput = new byte[fsInput.Length - 1]; // what do you need that big buffer for anyways?
                //fsInput.Read(bytearrayinput, 0, bytearrayinput.Length);
                //cryptostream.Write(bytearrayinput, 0, bytearrayinput.Length);
    
                byte[] headerBuffer = new byte[54]; // buffer for our bmp header ... without any color tables or masks
    
                //i don't care for a s***load of checks here, it's just a proof of concept
                fsInput.Read(headerBuffer, 0, headerBuffer.Length);
                var biCompression = BitConverter.ToInt32(headerBuffer, 30); //get biComp from header
                if (biCompression != 0 && biCompression != 3)
                    throw new Exception("Oh noes! ... can i haz uncompressed bmp?"); //die like cheesburger cat
                fsEncrypted.Write(headerBuffer, 0, headerBuffer.Length);
                //so... buffer is copied without any encryption...
    
                fsInput.CopyTo(cryptostream); // copy the rest and encrypt it ... don't care about color tables and masks for now ... and let's just hope plaintext and ciphertext have the right size...
                
                cryptostream.Close();
                fsInput.Close();
                fsEncrypted.Close();
            }
