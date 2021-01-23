    // Constructor:
    // Utility.Cookies cookies = new Cookies(Request,Response);
    
    // Public methods:
    // Delete(string cookieToDelete) - Deletes a cookie.
    // Set(string cookieName, string cookieValue, DateTime expireTime) - Sets a cookie
    // Get(string cookieName) - Gets the value of a cookie
    // GetEncrypted(string cookieName) - Gets the value of a cookie and decrypts it.
    // SetEncrypted(string cookieName, string cookieValue, DateTime expireTime) - Sets the encrypted value of a cookie
    using System;
    using System.Text;
    using System.Web;
    using System.Security.Cryptography;
    using System.IO;
    
    namespace Utility
    {
        /// <summary>
        /// Used to edit and delete cookies.
        /// </summary>
        public class Cookies
        {
            private const string COOKIE_PASSWORD = "This cookie is very encrypted!!!";
            private const int IV_SIZE = 16;
            private HttpRequest _request;
            private HttpResponse _response;
            private Cookies()
            {
                // Use the other constructor.
            }
            public Cookies(HttpRequest request, HttpResponse response)
            {
                _request = request;
                _response = response;
            }
            /// <summary>
            /// Deletes a cookie.
            /// </summary>
            /// <param name="cookieToDelete"></param>
            public void Delete(string cookieToDelete)
            {
                if (_request.Cookies[cookieToDelete] != null)
                {
                    _response.Cookies.Remove(cookieToDelete);
                    HttpCookie myCookie = new HttpCookie(cookieToDelete);
                    myCookie.Expires = DateTime.Now.AddDays(-2d);
                    _response.Cookies.Add(myCookie);
                }
                return;
            }
            /// <summary>
            /// Sets the value of a cookie.
            /// </summary>
            /// <param name="cookieName"></param>
            /// <param name="cookieValue"></param>
            public void Set(string cookieName, string cookieValue)
            {
                Set(cookieName, cookieValue, DateTime.Now.AddMonths(1));
                return;
            }
            /// <summary>
            /// Sets the value of a cookie.
            /// </summary>
            /// <param name="cookieName"></param>
            /// <param name="cookieValue"></param>
            public void Set(string cookieName, string cookieValue, DateTime expireTime)
            {
                HttpCookie newCookie;
                newCookie = _response.Cookies[cookieName];
                if (newCookie == null)
                {
                    newCookie = new HttpCookie(cookieName, cookieValue);
                    newCookie.Expires = expireTime;
                    _response.Cookies.Add(newCookie);
                }
                else
                {
                    newCookie.Value = cookieValue;
                    newCookie.Expires = DateTime.Now.AddMonths(1);
                }
                return;
            }
            /// <summary>
            /// Gets the value of a cookie.
            /// </summary>
            /// <param name="cookieName"></param>
            /// <returns></returns>
            public string Get(string cookieName)
            {
                if (_request.Cookies[cookieName] != null)
                {
                    return _request.Cookies[cookieName].Value;
                }
                return string.Empty;
            }
            /// <summary>
            /// Generate a random IV.
            /// </summary>
            /// <returns></returns>
            private static byte[] IV()
            {
                byte[] data = new byte[IV_SIZE];
                System.Security.Cryptography.RandomNumberGenerator rnd = System.Security.Cryptography.RandomNumberGenerator.Create();
                rnd.GetBytes(data);
                return data;
            }
            /// <summary>
            /// Extracts the IV from a message.
            /// </summary>
            /// <param name="message"></param>
            /// <returns></returns>
            private static byte[] IV(ref byte[] message)
            {
                byte[] returnValue = new byte[IV_SIZE];
                byte[] newMessage = new byte[message.Length - IV_SIZE];
                Array.Copy(message, returnValue, IV_SIZE);
                Array.Copy(message, IV_SIZE, newMessage, 0, newMessage.Length);
                message = newMessage;
                return returnValue;
            }
            /// <summary>
            /// Gets the value of a cookie and decrypts it.
            /// </summary>
            /// <param name="cookieName"></param>
            /// <returns></returns>
            public string GetEncrypted(string cookieName)
            {
                string cookieValue;
                byte[] iv;            
                byte[] encrypted;
                cookieValue = Get(cookieName);
                if (!String.IsNullOrEmpty(cookieValue))
                {
                    encrypted = System.Convert.FromBase64String(cookieValue);
                    iv = IV(ref encrypted);
                    // Create a new instance of the AesManaged 
                    // class.  This generates a new key and initialization  
                    // vector (IV). 
                    // Decrypt the bytes to a string. 
                    cookieValue = DecryptStringFromBytes_Aes(encrypted, Key(), iv);
                }
                return cookieValue;
            }
            /// <summary>
            /// Sets the value of a cookie. Encrypt it so the client can't mess with it.
            /// </summary>
            /// <param name="cookieName"></param>
            /// <param name="cookieValue"></param>
            /// <param name="expireTime"></param>
            public void SetEncrypted(string cookieName, string cookieValue, DateTime expireTime)
            {
                string encryptedValue;
                byte[] iv;
                byte[] encrypted;
                byte[] encryptedWithIV;
                // Encrypt the string to an array of bytes. 
                iv = IV();
                encrypted = EncryptStringToBytes_Aes(cookieValue, Key(), iv);
                encryptedWithIV = new byte[iv.Length + encrypted.Length];
                Array.Copy(iv, encryptedWithIV, iv.Length);
                Array.Copy(encrypted, 0, encryptedWithIV, iv.Length, encrypted.Length);
                encryptedValue = System.Convert.ToBase64String(encryptedWithIV);
                Set(cookieName, encryptedValue, expireTime);
                return;
            }
            private static byte[] EncryptStringToBytes_Aes(string plainText, byte[] key, byte[] iv)
            {
                byte[] encrypted;
                // Create an AesManaged object 
                // with the specified key and IV. 
                using (AesManaged aesAlg = new AesManaged())
                {
                    aesAlg.Key = key;
                    aesAlg.IV = iv;
    
                    // Create a decrytor to perform the stream transform.
                    ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);
    
                    // Create the streams used for encryption. 
                    using (MemoryStream msEncrypt = new MemoryStream())
                    {
                        using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                        {
                            using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                            {
    
                                //Write all data to the stream.
                                swEncrypt.Write(plainText);
                            }
                            encrypted = msEncrypt.ToArray();
                        }
                    }
                }
    
    
                // Return the encrypted bytes from the memory stream. 
                return encrypted;
    
            }
            private static byte[] Key()
            {
                return System.Text.ASCIIEncoding.ASCII.GetBytes(COOKIE_PASSWORD);
            }
            private static string DecryptStringFromBytes_Aes(byte[] cipherText, byte[] key, byte[] iv)
            {
                // Declare the string used to hold 
                // the decrypted text. 
                string plaintext = null;
    
                // Create an AesManaged object 
                // with the specified key and IV. 
                using (AesManaged aesAlg = new AesManaged())
                {
                    aesAlg.Key = key;
                    aesAlg.IV = iv;
    
                    // Create a decrytor to perform the stream transform.
                    ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);
    
                    // Create the streams used for decryption. 
                    using (MemoryStream msDecrypt = new MemoryStream(cipherText))
                    {
                        using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                        {
                            using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                            {
    
                                // Read the decrypted bytes from the decrypting stream 
                                // and place them in a string.
                                plaintext = srDecrypt.ReadToEnd();
                            }
                        }
                    }
    
                }
    
                return plaintext;
    
            }
    
        }
    }
