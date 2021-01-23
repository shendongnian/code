    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;
    using System.Configuration;
    using System.IO;
    
    namespace SyncFolders {
     class Program {
      private static string rootSourcePath = ConfigurationManager.AppSettings["RootSourcePath"];
      private static string rootDestinationPath = ConfigurationManager.AppSettings["RootDestinationPath"];
      private static int _itemsSynced = 0;
    
      static void Main(string[] args) {
       if (Directory.Exists(rootSourcePath)) {
        if (Directory.Exists(rootDestinationPath)) {
         var startTime = DateTime.Now;
         Console.WriteLine("Source: " + rootSourcePath);
         Console.WriteLine("Destination: " + rootDestinationPath);
         Console.WriteLine("You are about to copy any DIFFERENT folders/files from source to destination. Continue?");
         Console.ReadLine();
    
         DirectoryInfo source = new DirectoryInfo(rootSourcePath);
    
         WalkDirectoryTree(source, rootDestinationPath);
    
         Console.WriteLine("");
         Console.WriteLine("Started at " + startTime);
         Console.WriteLine("Finished at " + DateTime.Now);
    
         Console.WriteLine("");
    
         if (_itemsSynced > 0)
          Console.WriteLine("Folders/files added: " + _itemsSynced);
         else
          Console.WriteLine("Everything was already in sync!");
    
         Console.ReadLine();
        } else {
         Console.WriteLine("Folder not found: " + rootDestinationPath);
         Console.ReadLine();
        }
       } else {
        Console.WriteLine("Folder not found: " + rootSourcePath);
        Console.ReadLine();
       }
      }
    
      private static void WalkDirectoryTree(DirectoryInfo source, string destination) {
       System.IO.FileInfo[] files = null;
       System.IO.DirectoryInfo[] subDirs = null;
    
       files = source.GetFiles("*.*");
    
       if (files != null) {
        foreach(System.IO.FileInfo fi in files) {
         string fullSourcePath = fi.FullName;
         string fullDestinationPath = fi.FullName.Replace(source.FullName, destination);
    
         if (!File.Exists(fullDestinationPath)) {
          File.Copy(fullSourcePath, fullDestinationPath);
          Console.WriteLine(fullSourcePath);
          _itemsSynced++;
         }
        }
    
        // Now find all the subdirectories under this directory.
        subDirs = source.GetDirectories();
    
        foreach(System.IO.DirectoryInfo dirInfo in subDirs) {
         string fullSourcePath = dirInfo.FullName;
         string fullDestinationPath = fullSourcePath.Replace(source.FullName, destination);
    
         if (!Directory.Exists(fullDestinationPath)) {
          Directory.CreateDirectory(fullDestinationPath);
          Console.WriteLine(fullSourcePath);
          _itemsSynced++;
         }
    
         // Resursive call for each subdirectory.
         WalkDirectoryTree(dirInfo, fullDestinationPath);
        }
       }
      }
     }
    }
