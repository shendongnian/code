    using System;
    using System.Text;
    using System.Security.Cryptography;
    using System.IO;
    class AES_CFB_XorKeyStream
    {
        static void Main(string[] args)
        {
            byte[] data = Encoding.UTF8.GetBytes("0123456789");
            byte [] k1 = Encoding.UTF8.GetBytes("0123456789abcdef");
            byte [] r1 = Encoding.UTF8.GetBytes("1234567890abcdef");
            Console.WriteLine("original " + BitConverter.ToString(data));
            using (RijndaelManaged Aes128 = new RijndaelManaged())
            {
                Aes128.BlockSize = 128;
                Aes128.KeySize = 128;
                Aes128.Mode = CipherMode.CFB;
                Aes128.FeedbackSize = 128;
                Aes128.Padding = PaddingMode.None;
                Aes128.Key = k1;
                Aes128.IV = r1;
                using (var encryptor = Aes128.CreateEncryptor())
                using (var msEncrypt = new MemoryStream())
                using (var csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                using (var bw = new BinaryWriter(csEncrypt, Encoding.UTF8))
                {
                    bw.Write(data);
                    bw.Close();
                    data = msEncrypt.ToArray();
                    Console.WriteLine("crypted " + BitConverter.ToString(data));
                }
            }
            using (RijndaelManaged Aes128 = new RijndaelManaged())
            {
                Aes128.BlockSize = 128;
                Aes128.KeySize = 128;
                Aes128.Mode = CipherMode.CFB;
                Aes128.FeedbackSize = 128;
                Aes128.Padding = PaddingMode.None;
                Aes128.Key = k1;
                Aes128.IV = r1;
                using (var decryptor = Aes128.CreateDecryptor())
                using (var msEncrypt = new MemoryStream())
                using (var csEncrypt = new CryptoStream(msEncrypt, decryptor, CryptoStreamMode.Write))
                using (var bw = new BinaryWriter(csEncrypt, Encoding.UTF8))
                {
                    bw.Write(data);
                    bw.Close();
                    data = msEncrypt.ToArray();
                    Console.WriteLine("decrypted " + BitConverter.ToString(data));
                }
            }
        }
    }
