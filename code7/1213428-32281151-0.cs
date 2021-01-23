    using System;
    using System.IO;
    using System.Security.Cryptography;
    using System.Text;
    using System.Windows.Forms;
    
    namespace StackOverflow
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
    
            private void textBox3_TextChanged(object sender, EventArgs e)
            {
                textBox1.Text = EncryptionHelper.EncryptAndEncode(textBox3.Text);
                textBox2.Text = EncryptionHelper.DecodeAndDecrypt(textBox1.Text);
            }
        }
    
        public static class EncryptionHelper
        {
            private static int BlockSize = 16;
    
            private static byte[] Key
            {
                get
                {
                    byte[] hash = SHA1.Create().ComputeHash(Encoding.UTF8.GetBytes("BlahBlahBlah"));
                    byte[] key = new byte[BlockSize];
                    Array.Copy(hash, 0, key, 0, BlockSize);
                    return key;
                }
            }
    
            private static byte[] IV
            {
                get
                {
                    StringBuilder builder = new StringBuilder();
                    Random random = new Random();
                    for (int i = 0; i < BlockSize; i++)
                    {
                        char ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
                        builder.Append(ch);
                    }
                    return Encoding.UTF8.GetBytes(builder.ToString());
                }
            }
    
            public static string DecodeAndDecrypt(string cipherText)
            {
                byte[] cipherBytes = Convert.FromBase64String(cipherText);
                string decodeAndDecrypt = AesDecrypt(cipherBytes);
                return decodeAndDecrypt;
            }
    
            public static string EncryptAndEncode(string plaintext)
            {
                return Convert.ToBase64String(AesEncrypt(plaintext));
            }
    
            public static string AesDecrypt(Byte[] inputBytes)
            {
                Byte[] outputBytes = inputBytes;
    
                string plaintext = string.Empty;
    
                using (MemoryStream memoryStream = new MemoryStream(outputBytes))
                {
                    using (CryptoStream cryptoStream = new CryptoStream(memoryStream, GetCryptoAlgorithm().CreateDecryptor(Key, IV), CryptoStreamMode.Read))
                    {
                        using (BinaryReader srDecrypt = new BinaryReader(cryptoStream))
                        {
                            outputBytes = srDecrypt.ReadBytes(inputBytes.Length);
                            plaintext = Encoding.UTF8.GetString(outputBytes);
                        }
                    }
                }
                return plaintext;
            }
    
            public static byte[] AesEncrypt(string inputText)
            {
                byte[] inputBytes = UTF8Encoding.UTF8.GetBytes(inputText);
                byte[] result = null;
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    using (CryptoStream cryptoStream = new CryptoStream(memoryStream, GetCryptoAlgorithm().CreateEncryptor(Key, IV), CryptoStreamMode.Write))
                    {
                        cryptoStream.Write(inputBytes, 0, inputBytes.Length);
                        cryptoStream.FlushFinalBlock();
                        result = memoryStream.ToArray();
                    }
                }
                return result;
            }
    
            private static RijndaelManaged GetCryptoAlgorithm()
            {
                RijndaelManaged algorithm = new RijndaelManaged();
                algorithm.Padding = PaddingMode.PKCS7;
                algorithm.Mode = CipherMode.CBC;
                algorithm.KeySize = 128;
                algorithm.BlockSize = 128;
                return algorithm;
            }
        }
    }
