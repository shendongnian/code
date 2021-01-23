    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Security.Cryptography;
    using System.IO;
    using System.Diagnostics;
    
    namespace OpenbravoDecrypter
    {
        class Program
        {
            static void Main(string[] args)
            {
                var decrypted = Decrypt("19215E9576DE6A96D5F03FE1D3073DCC", "mark");
                Console.ReadLine();
            }
    
            static string Decrypt(string ciphertext, string username)
            {
                //Ciphertext is given as a hex string, convert it back to bytes
                if(ciphertext.Length % 2 == 1) ciphertext = "0" + ciphertext; //pad a zero left is necessary
                byte[] ciphertext_bytes = new byte[ciphertext.Length / 2];
                for(int i=0; i < ciphertext.Length; i+=2)
                    ciphertext_bytes[i / 2] = Convert.ToByte(ciphertext.Substring(i, 2), 16);
    
                //Get an instance of a tripple-des descryption
                TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();        
                tdes.Mode = CipherMode.ECB; //ECB as Cipher Mode
                tdes.Padding = PaddingMode.PKCS7; //PKCS7 padding (same as PKCS5, good enough)
    
                byte[] key_bytes = DeriveKeyWorkAround(username);
                Console.WriteLine("Derived Key: " + BitConverter.ToString(key_bytes));
                //Start the decryption, give it the key, and null for the IV.
                var decryptor = tdes.CreateDecryptor(key_bytes, null);
                //Decrypt it.
                var plain = decryptor.TransformFinalBlock(ciphertext_bytes, 0, ciphertext_bytes.Length);
    
                //Output the result as hex string and as UTF8 encoded string
                Console.WriteLine("Plaintext Bytes: " + BitConverter.ToString(plain));
                var s = Encoding.UTF8.GetString(plain);
                Console.WriteLine("Plaintext UTF-8: " + s);
                return s;
            }
    
            /* Work around the fact that we don't have a C# implementation of SHA1PRNG by calling into a custom-prepared java file..*/
            static StringBuilder procOutput = new StringBuilder();
            static byte[] DeriveKeyWorkAround(string username)
            {
                username = "cypherkey" + username;
                //Invoke java on our file
                Process p = new Process();
                p.StartInfo.FileName = "cmd.exe";
                p.StartInfo.Arguments = "/c java PasswordDeriver \"" + username + "\"";
                p.StartInfo.RedirectStandardOutput = true;
                p.OutputDataReceived += (e, d) => procOutput.Append(d.Data);
                p.StartInfo.UseShellExecute = false;
                p.Start();
                p.BeginOutputReadLine();
                p.WaitForExit();
    
                //Convert it back
                byte[] key = procOutput.ToString().Split(' ').Select(hex => Convert.ToByte(hex, 16)).ToArray();
    
                return key;
            }
    
    
            /* This function copies the functionality of the GNU Implementation of SHA1PRNG. 
             * Currently, it's broken, meaning that it doesn't produce the same output as the SUN implenetation of SHA1PRNG.
             * Case 1: the GNU implementation is the same as the SUN implementation, and this re-implementation is just wrong somewhere
             * Case 2: the GNU implementation is not the same the SUN implementation, therefore you'd need to reverse engineer some existing
             * SUN implementation and correct this method. 
           */
            static byte[] DeriveKey(string username)
            {
                //adjust
                username = "cypherkey" + username;
                byte[] user = Encoding.UTF8.GetBytes(username);
                //Do SHA1 magic
                var sha1 = new SHA1CryptoServiceProvider();
                var seed = new byte[20];
                byte[] data = new byte[40];
                int seedpos = 0;
                int datapos = 0;
    
                //init stuff
                byte[] digestdata;
                digestdata = sha1.ComputeHash(data);
                Array.Copy(digestdata, 0, data, 0, 20);
    
                /* seeding part */
                for (int i=0; i < user.Length; i++)
                {
                    seed[seedpos++ % 20] ^= user[i];
                }
                seedpos %= 20;
    
                /* Generate output bytes */
                byte[] bytes = new byte[24]; //we need 24 bytes (= 192 bit / 8)
    
                int loc = 0;
                while (loc < bytes.Length)
                {
                    int copy = Math.Min(bytes.Length - loc, 20 - datapos);
    
                    if (copy > 0)
                    {
                        Array.Copy(data, datapos, bytes, loc, copy);
                        datapos += copy;
                        loc += copy;
                    }
                    else
                    {
                        // No data ready for copying, so refill our buffer.
                        Array.Copy(seed, 0, data, 20, 20);
                        byte[] digestdata2 = sha1.ComputeHash(data);
                        Array.Copy(digestdata2, 0, data, 0, 20);
                        datapos = 0;
                    }
                }
                Console.WriteLine("GENERATED KEY:\n");
                for(int i=0; i < bytes.Length; i++)
                {
                    Console.Write(bytes[i].ToString("X").PadLeft(2, '0'));
                }
    
                return bytes;
            } 
        }
    }
