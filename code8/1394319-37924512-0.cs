     private void fix_desktop()
        {
            string pathington = Environment.SpecialFolder.Desktop + @"\MrEncrypto\";
            bool check = !Directory.Exists(pathington);
            string finaloutput = Environment.SpecialFolder.Desktop + @"\MrEncrypto\";
            if (!check)
            {
                Directory.CreateDirectory(pathington);
            }
            else
            {
                foreach (string file in Directory.GetFiles(Environment.SpecialFolder.Desktop + @"\MrEncrypto"))
                {
                    File.Delete(file);
                }
            }
            foreach (string file in files)
            {
                try
                {
                    FileStream fsInput = new FileStream(file, FileMode.Open, FileAccess.Read);
                    FileStream fsencrypt = new FileStream(finaloutput + Path.GetFileName(file), FileMode.Create, FileAccess.Write);
                    /** DESCryptoServiceProvider DES = new DESCryptoServiceProvider();
                     DES.Key = ASCIIEncoding.ASCII.GetBytes(key);
                     DES.IV = ASCIIEncoding.ASCII.GetBytes(IV);**/
                    AesCryptoServiceProvider DES = new AesCryptoServiceProvider();
                    DES.BlockSize = 128;
                    DES.KeySize = 256;
                    DES.IV = ASCIIEncoding.ASCII.GetBytes(IV);
                    DES.Key = ASCIIEncoding.ASCII.GetBytes(key);
                    DES.Padding = PaddingMode.PKCS7;
                    DES.Mode = CipherMode.CBC;
                    ICryptoTransform desencrypt = DES.CreateEncryptor();
                    CryptoStream ocstream = new CryptoStream(fsencrypt, desencrypt, CryptoStreamMode.Write);
                    //reading time
                    byte[] filetobyte = new byte[fsInput.Length - 1];
                    fsInput.Read(filetobyte, 0, filetobyte.Length);
                    ocstream.Write(filetobyte, 0, filetobyte.Length);
                    fsInput.Close();
                    ocstream.Close();
                    fsencrypt.Close();
                }
                catch
                {
                    continue;
                }
            }//foreach
            SystemSounds.Beep.Play();
            Encrypto.Enabled = false;
        }//function
