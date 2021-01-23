    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using ICSharpCode.SharpZipLib.Core;
    using ICSharpCode.SharpZipLib.Zip;
    using System.IO;
    using System.Security.Cryptography;
    
    namespace TestApp
    {
        class Program
        {
            private static MD5 hash = MD5.Create();
            static void Main(string[] args)
            {
                if(args.Length < 1)
                {
                    Console.WriteLine("Usage: TestApp.exe zipfilename [username] [password]");
                    return;
                }
    
                string filename = args[0],
                       username = args.Length == 2 ? args[1] : "default",
                       password = args.Length == 3 ? args[2] : null;
    
                Dictionary<string, string> emulatedStructure = ExtractZipFile(filename, password, username);
    
                using(FileStream fs = File.Open(filename+".output",FileMode.OpenOrCreate))
                {
                    using (StreamWriter writer = new StreamWriter(fs))
                    {
                        foreach(KeyValuePair<string, string> pair in emulatedStructure)
                        {
                            writer.WriteLine(pair.Key + "::>" + pair.Value);
                        }
                    }
                }
            }
    
            private static byte[] CreateBinaryHash(byte[] original)
            {
                hash.Initialize();
                return hash.ComputeHash(original);
            }
    
            private static string CreateHash(string original, Encoding encoder = null)
            {
                if (encoder == null) encoder = Encoding.UTF8;
                byte[] data = encoder.GetBytes(original);
                data = CreateBinaryHash(data);
                return BitConverter.ToString(data).Replace("-", "");
            }
            
            private static Dictionary<string, string> ExtractZipFile(string archiveFilenameIn, string password, string UserName = "global")
            {
                Dictionary<string, string> result = new Dictionary<string, string>();
                
                ZipFile zf = null;
                try
                {
                    FileStream fs = File.OpenRead(archiveFilenameIn);
                    zf = new ZipFile(fs);
                    if (!string.IsNullOrEmpty(password))
                    {
                        zf.Password = password;     // AES encrypted entries are handled automatically
                    }
                    foreach (ZipEntry zipEntry in zf)
                    {
                        if (!zipEntry.IsFile)
                        {
                            continue;           // Ignore directories
                        }
                        string entryFileName = zipEntry.Name;
                        // to remove the folder from the entry:- entryFileName = Path.GetFileName(entryFileName);
                        // Optionally match entrynames against a selection list here to skip as desired.
                        // The unpacked length is available in the zipEntry.Size property.
                        byte[] buffer = new byte[4096];     // 4K is optimum
                        Stream zipStream = zf.GetInputStream(zipEntry);
    
                        // Manipulate the output filename here as desired.
                        string fullZipToPath = UserName+"."+CreateHash(entryFileName)+".dat";
    
                        /* Since we have a flat structure... Don't do the following lines
                        string directoryName = Path.GetDirectoryName(fullZipToPath);
                        if (directoryName.Length > 0)
                            Directory.CreateDirectory(directoryName);
                        */
    
                        //Instead we add it to our dictionary which we can store wherever we want, just in case...
                        result.Add(entryFileName, fullZipToPath);
    
                        // Unzip file in buffered chunks. This is just as fast as unpacking to a buffer the full size
                        // of the file, but does not waste memory.
                        // The "using" will close the stream even if an exception occurs.
                        using (FileStream streamWriter = File.Create(fullZipToPath))
                        {
                            StreamUtils.Copy(zipStream, streamWriter, buffer);
                        }
                    }
                }
                finally
                {
                    if (zf != null)
                    {
                        zf.IsStreamOwner = true; // Makes close also shut the underlying stream
                        zf.Close(); // Ensure we release resources
                    }
                }
                return result;
            }
        }
    }
