    var myFile = your file;
       if (System.IO.File.Exists (myFile.Path)) {
              var decreypt = new FileEncryptDecrypt ();
    
              decreypt.DecryptFile (myFile.Path/*input file*/, tempFilePath/*output*/);
            } 
---------------------
 
        using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Security.Cryptography;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace Website.Server
    {
    
    
        public class FileEncryptDecrypt
        {
          //  private const string password = @"myKey123"; // Your Key Here
    
            /// <summary>
            /// Encrypts a file using AES 
            /// </summary>
            /// <param name="inputFile">inputFile Path</param>
            /// <param name="outputFile">outputFile path</param>
            public  void EncryptFile(string inputFile, string outputFile)
            {
    
                try
                {
                    UnicodeEncoding UE = new UnicodeEncoding();
                    byte[] key = UE.GetBytes(Settings.ServerSettings.EncDecKey);
    
                    string cryptFile = outputFile;
                    FileStream fsCrypt = new FileStream(cryptFile, FileMode.Create);
    
                    //  RijndaelManaged RMCrypto = new RijndaelManaged();
                    var RMCrypto = Aes.Create();
                    CryptoStream cs = new CryptoStream(fsCrypt,
                        RMCrypto.CreateEncryptor(key, key),
                        CryptoStreamMode.Write);
    
                    FileStream fsIn = new FileStream(inputFile, FileMode.Open);
    
                    int data;
                    while ((data = fsIn.ReadByte()) != -1)
                        cs.WriteByte((byte)data);
    
    
                    fsIn.Dispose();
                    cs.Dispose();
                    fsCrypt.Dispose();
                }
                catch(Exception ex)
                {
                  var msg=ex.Message   ;  /// MessageBox.Show("Encryption failed!", "Error");
                }
            }
    
            /// <summary>
            /// Decrypts a file using Aes .
            /// </summary>
            /// <param name="inputFile">inputFile Path</param>
            /// <param name="outputFile">outputFile path</param>
            public  void DecryptFile(string inputFile, string outputFile)
            {
                try
                {
    
                    UnicodeEncoding UE = new UnicodeEncoding();
                    byte[] key = UE.GetBytes(Settings.ServerSettings.EncDecKey);
    
                    FileStream fsCrypt = new FileStream(inputFile, FileMode.Open);
    
                    var RMCrypto = Aes.Create();
                    // RijndaelManaged RMCrypto = new RijndaelManaged();
    
                    CryptoStream cs = new CryptoStream(fsCrypt,
                        RMCrypto.CreateDecryptor(key, key),
                        CryptoStreamMode.Read);
    
                    FileStream fsOut = new FileStream(outputFile, FileMode.Create);
    
                    int data;
                    while ((data = cs.ReadByte()) != -1)
                        fsOut.WriteByte((byte)data);
    
                    fsOut.Dispose();
                    cs.Dispose();
                    fsCrypt.Dispose();
    
                }
                catch(Exception ex)
                {
                   var msg=ex .Message  ;
                }
            }
    
            private static void EncryptData(String inName, String outName, byte[] rijnKey, byte[] rijnIV)
            {
                //Create the file streams to handle the input and output files.
                FileStream fin = new FileStream(inName, FileMode.Open, FileAccess.Read);
                FileStream fout = new FileStream(outName, FileMode.OpenOrCreate, FileAccess.Write);
                fout.SetLength(0);
    
                //Create variables to help with read and write.
                byte[] bin = new byte[100]; //This is intermediate storage for the encryption.
                long rdlen = 0;              //This is the total number of bytes written.
                long totlen = fin.Length;    //This is the total length of the input file.
                int len;                     //This is the number of bytes to be written at a time.
    
                var rijn = System.Security.Cryptography.Aes.Create();
    
                //   SymmetricAlgorithm rijn = new SymmetricAlgorithm .Create(); //Creates the default implementation, which is RijndaelManaged.         
                CryptoStream encStream = new CryptoStream(fout, rijn.CreateEncryptor(rijnKey, rijnIV), CryptoStreamMode.Write);
    
                Console.WriteLine("Encrypting...");
    
                //Read from the input file, then encrypt and write to the output file.
                while (rdlen < totlen)
                {
                    len = fin.Read(bin, 0, 100);
                    encStream.Write(bin, 0, len);
                    rdlen = rdlen + len;
                    Console.WriteLine("{0} bytes processed", rdlen);
                }
    
                encStream.Dispose();
                fout.Dispose();
                fin.Dispose();
            }
        }
    }
