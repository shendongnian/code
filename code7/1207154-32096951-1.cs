    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Security.Cryptography;
     
    namespace EncryptDecryptTest
    {
        class Program
        {
            class AesBase64Wrapper
            {
                private static string IV = "IV_VALUE_16_BYTE";
                private static string PASSWORD = "PASSWORD_VALUE";
                private static string SALT = "SALT_VALUE";
     
                public static string EncryptAndEncode(string raw)
                {
                    using (var csp = new AesCryptoServiceProvider())
                    {
                        ICryptoTransform e = GetCryptoTransform(csp, true);
                        byte[] inputBuffer = Encoding.UTF8.GetBytes(raw);
                        byte[] output = e.TransformFinalBlock(inputBuffer, 0, inputBuffer.Length);
                        string encrypted = Convert.ToBase64String(output);
                        return encrypted;
                    }
                }
     
                public static string DecodeAndDecrypt(string encrypted)
                {
                    using (var csp = new AesCryptoServiceProvider())
                    {
                        var d = GetCryptoTransform(csp, false);
                        byte[] output = Convert.FromBase64String(encrypted);
                        byte[] decryptedOutput = d.TransformFinalBlock(output, 0, output.Length);
                        string decypted = Encoding.UTF8.GetString(decryptedOutput);
                        return decypted;
                    }
                }
     
                private static ICryptoTransform GetCryptoTransform(AesCryptoServiceProvider csp, bool encrypting)
                {
                    csp.Mode = CipherMode.CBC;
                    csp.Padding = PaddingMode.PKCS7;
                    var spec = new Rfc2898DeriveBytes(Encoding.UTF8.GetBytes(PASSWORD), Encoding.UTF8.GetBytes(SALT), 65536);
                    byte[] key = spec.GetBytes(16);
     
     
                    csp.IV = Encoding.UTF8.GetBytes(IV);
                    csp.Key = key;
                    if (encrypting)
                    {
                        return csp.CreateEncryptor();
                    }
                    return csp.CreateDecryptor();
                }
            }
     
            static void Main(string[] args)
            {
                string encryptMe;
                string encrypted;
                string decrypted;
     
                encryptMe = "please encrypt me";
                Console.WriteLine("encryptMe = " + encryptMe);
     
                encrypted = AesBase64Wrapper.EncryptAndEncode(encryptMe);
                Console.WriteLine("encypted: " + encrypted);
     
                decrypted = AesBase64Wrapper.DecodeAndDecrypt(encrypted);
                Console.WriteLine("decrypted: " + decrypted);
     
                Console.WriteLine("press any key to exit....");
                Console.ReadKey();
            }
        }
    }
