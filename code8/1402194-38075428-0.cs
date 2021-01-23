    public class FolderEntry {
    
        public string Name {
          get; set;
        }
    
        public List<FolderEntry> FolderEntries {
          get; set;
        }
    
        public List<FileEntry> Files {
          get; set;
        }
    
    
      }
    
    
      public class FileEntry {
    
        public string Name {
          get; set;
        }
    
        public string FileType {
          get; set;
        }
    
      }
