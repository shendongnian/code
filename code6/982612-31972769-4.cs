    /// <summary>
    /// Specifies which fields are valid in a FileDescriptor Structure
    /// </summary>    
    [Flags]
    enum FileDescriptorFlags : uint
    {
        ClsId = 0x00000001,
        SizePoint = 0x00000002,
        Attributes = 0x00000004,
        CreateTime = 0x00000008,
        AccessTime = 0x00000010,
        WritesTime = 0x00000020,
        FileSize = 0x00000040,
        ProgressUI = 0x00004000,
        LinkUI = 0x00008000,
        Unicode = 0x80000000,
    }
    internal static class FileDescriptorReader
    {        
        internal sealed class FileDescriptor
        {
            public FileDescriptorFlags Flags{get;set;}
            public Guid ClassId{get;set;}
            public Size Size{get;set;}
            public Point Point{get;set;}
            public FileAttributes FileAttributes{get;set;}
            public DateTime CreationTime{get;set;}
            public DateTime LastAccessTime{get;set;}
            public DateTime LastWriteTime{get;set;}
            public Int64 FileSize{get;set;}
            public string FileName{get;set;}
            public FileDescriptor(BinaryReader reader)
            {
                //Flags
                Flags = (FileDescriptorFlags)reader.ReadUInt32();
                //ClassID
                ClassId = new Guid(reader.ReadBytes(16));
                //Size
                Size = new Size(reader.ReadInt32(), reader.ReadInt32());
                //Point
                Point = new Point(reader.ReadInt32(), reader.ReadInt32());
                //FileAttributes
                FileAttributes = (FileAttributes)reader.ReadUInt32();
                //CreationTime
                CreationTime = new DateTime(1601,1,1).AddTicks(reader.ReadInt64());
                //LastAccessTime
                LastAccessTime = new DateTime(1601,1,1).AddTicks(reader.ReadInt64());
                //LastWriteTime
                LastWriteTime = new DateTime(1601, 1, 1).AddTicks(reader.ReadInt64());
                //FileSize
                FileSize = reader.ReadInt64();
                //FileName
                byte[] nameBytes = reader.ReadBytes(520);
                int i = 0; 
                while(i < nameBytes.Length)
                {
                    if (nameBytes[i] == 0 && nameBytes[i + 1] == 0)
                        break;
                    i++;
                    i++;
                }
                FileName = UnicodeEncoding.Unicode.GetString(nameBytes, 0, i);
            }
        }
        public static IEnumerable<FileDescriptor> Read(Stream fileDescriptorStream)
        {
            BinaryReader reader = new BinaryReader(fileDescriptorStream);
            var count = reader.ReadUInt32();
            while (count > 0)
            {
                FileDescriptor descriptor = new FileDescriptor(reader);
                yield return descriptor;
                count--;
            }
        }
        public static IEnumerable<string> ReadFileNames(Stream fileDescriptorStream)
        {
            BinaryReader reader = new BinaryReader(fileDescriptorStream);
            var count = reader.ReadUInt32();
            while(count > 0)
            {
                FileDescriptor descriptor = new FileDescriptor(reader);
                yield return descriptor.FileName;
                count--;
            }
        }
    }
