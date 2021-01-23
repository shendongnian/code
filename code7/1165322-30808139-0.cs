    using System;
    using System.IO;
    using System.Collections.Generic;
    
    namespace Compression
    {
        public class ClassName
        {
            public static void Compress(string[] fileNames, string resultantFileName)
            {
                List<byte> bytesToWrite = new List<byte>();
    
                //add metadata about the number of files
                int filesLength = fileNames.Length;
                bytesToWrite.AddRange(BitConverter.GetBytes(filesLength));
    
                List<byte[]> files = new List<byte[]>();
                foreach(string fileName in fileNames)
                {
                    byte[] bytes = File.ReadAllBytes(fileName);
                    //add metadata about the size of each file
                    bytesToWrite.AddRange(BitConverter.GetBytes(bytes.Length));
                    files.Add(bytes);
                }
                foreach(byte[] bytes in files)
                {
                    //write the actual files itself
                    bytesToWrite.AddRange(bytes);
                }
                File.WriteAllBytes(resultantFileName, bytesToWrite.ToArray());
            }
    
            public static void Decompress(string fileName)
            {
                List<byte> bytes = new List<byte>(File.ReadAllBytes(fileName));
                //this int represents the number of files in the byte array
                int filesLength = BitConverter.ToInt32(bytes.ToArray(), 0);
    
                List<int> sizes = new List<int>();
                //get the size of each file
                for(int i = 0; i < filesLength; i++)
                {
                    //the first 2 bytes represent the number of files
                    //then each succeding int represents the size of each file
                    int size = BitConverter.ToInt32(bytes.ToArray(), 2 + i * 2);
                    sizes.Add(size);
                }
    
                //now read all the files
                for(int i = 0; i < filesLength; i++)
                {
                    int lastByteTillNow = 0;
                    for(int j = 0; j < i; j++)
                        lastByteTillNow += sizes[j];
                    File.WriteAllBytes("file " + i, bytes.GetRange(2 + 2 * filesLength + lastByteTillNow, sizes[i]).ToArray());
                }
            }
        }
    }  
