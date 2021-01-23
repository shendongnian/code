    using System;
    using System.Text;
    using System.IO;
    using System.IO.Compression;
     
    namespace CmprDir
    {
      class Program
      {
        delegate void ProgressDelegate(string sMessage);
     
        static void CompressFile(string sDir, string sRelativePath, GZipStream zipStream)
        {
          //Compress file name
          char[] chars = sRelativePath.ToCharArray();
          zipStream.Write(BitConverter.GetBytes(chars.Length), 0, sizeof(int));
          foreach (char c in chars)
            zipStream.Write(BitConverter.GetBytes(c), 0, sizeof(char));
     
          //Compress file content
          byte[] bytes = File.ReadAllBytes(Path.Combine(sDir, sRelativePath));
          zipStream.Write(BitConverter.GetBytes(bytes.Length), 0, sizeof(int));
          zipStream.Write(bytes, 0, bytes.Length);
        }
     
        static bool DecompressFile(string sDir, GZipStream zipStream, ProgressDelegate progress)
        {
          //Decompress file name
          byte[] bytes = new byte[sizeof(int)];
          int Readed = zipStream.Read(bytes, 0, sizeof(int));
          if (Readed < sizeof(int))
            return false;
     
          int iNameLen = BitConverter.ToInt32(bytes, 0);
          bytes = new byte[sizeof(char)];
          StringBuilder sb = new StringBuilder();
          for (int i = 0; i < iNameLen; i++)
          {
            zipStream.Read(bytes, 0, sizeof(char));
            char c = BitConverter.ToChar(bytes, 0);
            sb.Append(c);
          }
          string sFileName = sb.ToString();
          if (progress != null)
            progress(sFileName);
     
          //Decompress file content
          bytes = new byte[sizeof(int)];
          zipStream.Read(bytes, 0, sizeof(int));
          int iFileLen = BitConverter.ToInt32(bytes, 0);
     
          bytes = new byte[iFileLen];
          zipStream.Read(bytes, 0, bytes.Length);
     
          string sFilePath = Path.Combine(sDir, sFileName);
          string sFinalDir = Path.GetDirectoryName(sFilePath);
          if (!Directory.Exists(sFinalDir))
            Directory.CreateDirectory(sFinalDir);
     
          using (FileStream outFile = new FileStream(sFilePath, FileMode.Create, FileAccess.Write, FileShare.None))
            outFile.Write(bytes, 0, iFileLen);
     
          return true;
        }
     
        static void CompressDirectory(string sInDir, string sOutFile, ProgressDelegate progress)
        {
          string[] sFiles = Directory.GetFiles(sInDir, "*.*", SearchOption.AllDirectories);
          int iDirLen = sInDir[sInDir.Length - 1] == Path.DirectorySeparatorChar ? sInDir.Length : sInDir.Length + 1;
     
          using (FileStream outFile = new FileStream(sOutFile, FileMode.Create, FileAccess.Write, FileShare.None))
          using (GZipStream str = new GZipStream(outFile, CompressionMode.Compress))
            foreach (string sFilePath in sFiles)
            {
              string sRelativePath = sFilePath.Substring(iDirLen);
              if (progress != null)
                progress(sRelativePath);
              CompressFile(sInDir, sRelativePath, str);
            }
        }
     
        static void DecompressToDirectory(string sCompressedFile, string sDir, ProgressDelegate progress)
        {
          using (FileStream inFile = new FileStream(sCompressedFile, FileMode.Open, FileAccess.Read, FileShare.None))
          using (GZipStream zipStream = new GZipStream(inFile, CompressionMode.Decompress, true))
            while (DecompressFile(sDir, zipStream, progress));
        }
     
        public static int Main(string[] argv) 
        {
          if (argv.Length != 2)
          {
            Console.WriteLine("Usage: CmprDir.exe <in_dir compressed_file> | <compressed_file out_dir>");
            return 1;
          }
     
          string sDir;
          string sCompressedFile;
          bool bCompress = false;
          try
          {
            if (Directory.Exists(argv[0]))
            {
              sDir = argv[0];
              sCompressedFile = argv[1];
              bCompress = true;
            }
            else
              if (File.Exists(argv[0]))
              {
                sCompressedFile = argv[0];
                sDir = argv[1];
                bCompress = false;
              }
              else
              {
                Console.Error.WriteLine("Wrong arguments");
                return 1;
              }
     
            if (bCompress)
              CompressDirectory(sDir, sCompressedFile, (fileName) => { Console.WriteLine("Compressing {0}...", fileName); });
            else
              DecompressToDirectory(sCompressedFile, sDir, (fileName) => { Console.WriteLine("Decompressing {0}...", fileName); });
     
            return 0;
          }
          catch (Exception ex)
          {
            Console.Error.WriteLine(ex.Message);
            return 1;
          }
        }
      }
    }
