    class Program {
        static void Main(string[] args) {
          DirectoryInfo dInfo = new DirectoryInfo(@"D:\temp");
    
          foreach (DirectoryInfo item in dInfo.EnumerateDirectories()) {
    
            long sizeOfDir = DiskSize(item, true);
          
    
          Console.WriteLine("Size on disk in MB : " +
          "{0:N2} MB", ((double)sizeOfDir) / (1024 * 1024));
    
        
          }
          Console.ReadLine();
        }
    
        static long DiskSize(DirectoryInfo dInfo, bool includeSubDir) {
    
          long totalSize = dInfo.EnumerateFiles()
                       .Sum(file => file.Length);
    
    
          if (includeSubDir) {
    
            totalSize += dInfo.EnumerateDirectories()
                     .Sum(dir => DiskSize(dir, true));
          }
          return totalSize;
        }
      }
