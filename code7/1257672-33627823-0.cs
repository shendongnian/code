        private static object fileLock  = new object();
        public static void ReplaceLine(string path, int line, string replace)
        {
            lock(fileLock)
            {
                string[] text = File.ReadAllLines(path);
                text[line] = replace;      
                File.WriteAllLines(path, text);
            } 
        } 
    } 
