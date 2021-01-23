    using System;
    using System.Security.Cryptography;
    
    namespace StackOverflow
    {
        public class MACTripleDESTest
        {
            public static void Main(String[] args)
            {
                // example key
                byte[] key = new byte[24];
                for (int i = 0; i < key.Length; i++)
                {
                    key[i] = (byte) i;
                }
    
                // uses CBC MAC with zero initialization vector and Zero padding
                MACTripleDES macTDES = new MACTripleDES(key);
                byte[] result = macTDES.ComputeHash(new byte[] { 0x01, 0x02, 0x03, 0x04 });
    
                TripleDES tdes = new TripleDESCryptoServiceProvider();
                tdes.Key = key;
                tdes.Mode = CipherMode.ECB;
                tdes.Padding = PaddingMode.None;
                ICryptoTransform tf = tdes.CreateDecryptor();
                byte[] pt = tf.TransformFinalBlock(result, 0, tdes.BlockSize / 8);
                Console.WriteLine(BitConverter.ToString(pt));
            }
        }
    }
