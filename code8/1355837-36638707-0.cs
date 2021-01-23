    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.IO;
    
    namespace SOFAcrobatics
    {
        public static class Launcher
        {
            public static void Main (String [] paths)
            {
                List<String> pool = new List<String>();
                foreach (String path in paths)
                {
                    pool.AddRange(File.ReadAllLines(path));
                }
                // pool is now populated with all the lines of the files given from paths
            }
        }
    }
