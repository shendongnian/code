        public class LuaFile
        {
            public string FileName { get; set; }
            public string FilePath { get; set; }
            public LuaFile(string name, string path)
            {
                FileName = name;
                FilePath = path;
            }
            public override string ToString()
            {
                return FileName;
            }
        }
