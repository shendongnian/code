                internal const string Inputkey = "560A18CD-6346-4CF0-A2E8-671F9B6B9EA9";
               
                public static string EncryptRijndael(string text, string salt)
                {
                    if (string.IsNullOrEmpty(text))
                        throw new ArgumentNullException("text");
            
                    var aesAlg = NewRijndaelManaged(salt);
            
                    var encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);
                    var msEncrypt = new MemoryStream();
                    using (var csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    using (var swEncrypt = new StreamWriter(csEncrypt))
                    {
                        swEncrypt.Write(text);
                    }
            
                    return Convert.ToBase64String(msEncrypt.ToArray());
                }
               
                
                public static bool IsBase64String(string base64String)
                {
                    base64String = base64String.Trim();
                    return (base64String.Length % 4 == 0) &&
                           Regex.IsMatch(base64String, @"^[a-zA-Z0-9\+/]*={0,3}$", RegexOptions.None);
            
                }
            
               
                public static string DecryptRijndael(string cipherText, string salt)
                {
                    if (string.IsNullOrEmpty(cipherText))
                        throw new ArgumentNullException("cipherText");
            
                    if (!IsBase64String(cipherText))
                        throw new Exception("The cipherText input parameter is not base64 encoded");
            
                    string text;
            
                    var aesAlg = NewRijndaelManaged(salt);
                    var decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);
                    var cipher = Convert.FromBase64String(cipherText);
            
                    using (var msDecrypt = new MemoryStream(cipher))
                    {
                        using (var csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                        {
                            using (var srDecrypt = new StreamReader(csDecrypt))
                            {
                                text = srDecrypt.ReadToEnd();
                            }
                        }
                    }
                    return text;
                }
               
                private static RijndaelManaged NewRijndaelManaged(string salt)
                {
                    if (salt == null) throw new ArgumentNullException("salt");
                    var saltBytes = Encoding.ASCII.GetBytes(salt);
                    var key = new Rfc2898DeriveBytes(Inputkey, saltBytes);
            
                    var aesAlg = new RijndaelManaged();
                    aesAlg.Key = key.GetBytes(aesAlg.KeySize / 8);
                    aesAlg.IV = key.GetBytes(aesAlg.BlockSize / 8);
            
                    return aesAlg;
                }
               
                protected void Button1_Click(object sender, EventArgs e)
                {
                    TextBox1.Text = EncryptRijndael(TextBox1.Text, Inputkey);
                }
                protected void Button2_Click(object sender, EventArgs e)
                {
                    TextBox2.Text = DecryptRijndael(TextBox1.Text, Inputkey);
                }
