    using System;
    using System.IO;
    using System.Security.Cryptography;
    using System.Windows.Forms;
    
    namespace SO_AES
    {
        public partial class Form1 : Form
        {
            Random ran = new Random();
            public Form1()
            {
                InitializeComponent();
                using (var file = File.Open("Plaintext.txt", FileMode.OpenOrCreate))
                {
                    byte[] junkBytes = new byte[1000];
                    for (int i = 0; i < 1000; i++)
                    {
                        for (int j = 0; j < 1000; j++)
                        {
                            junkBytes[j] = (byte)ran.Next(0, 255);
                        }
                        file.Write(junkBytes, 0, junkBytes.Length);
                    }
                }
    
                using (var plainTextFile = File.Open("Plaintext.txt", FileMode.Open))
                {
                    using (var cryptoTextFile = File.Open("Crypto.txt", FileMode.OpenOrCreate))
                    {
                        encrypt(plainTextFile, cryptoTextFile);
                    }
                }
            }
    
            void encrypt(Stream inStream, Stream outStream)
            {
                using (SymmetricAlgorithm algorithm = AesCryptoServiceProvider.Create())
                {
                    algorithm.GenerateKey();
                    algorithm.GenerateIV();
                    byte[] iv = algorithm.IV;
                    byte[] key = algorithm.Key;
                    using (ICryptoTransform encryptor = algorithm.CreateEncryptor(key, iv))
                    {
                        using (CryptoStream cs = new CryptoStream(outStream, encryptor, CryptoStreamMode.Write))
                        {
                            BinaryWriter bw = new BinaryWriter(outStream);
                            bw.Write(iv);
                            byte[] readBuffer = new byte[1];
                            BinaryReader br = new BinaryReader(inStream);
                            while (br.Read(readBuffer, 0, readBuffer.Length) != 0)
                            {
                                cs.Write(readBuffer, 0, 1);
                            }
                        }
                    }
                }
                inStream.Close();
                outStream.Close();
            }
        }
    }
