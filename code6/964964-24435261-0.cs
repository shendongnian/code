    public static MemoryMappedFile MemFile(string path)
    {
         return MemoryMappedFile.CreateFromFile(
                   //include a readonly shared stream
                   File.Open(path, FileMode.Open, FileAccess.Read, FileShare.Read),
                   //not mapping to a name
                   null,
                   //use the file's actual size
                   0L, 
                   //read only access
                   MemoryMappedFileAccess.Read, 
                   //not configuring security
                   null,
                   //adjust as needed
                   HandleInheritability.None,
                   //close the previously passed in stream when done
                   false);
    }
