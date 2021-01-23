        public static void SplitCSV(string FilePath, string FileName)
        {
            //Read Specified file size
            int size = Int32.Parse(ConfigurationManager.AppSettings["FileSize"]);
            size *= 1024 * 1024;  //1 MB size
            
            int total = 0;
            int num = 0;
            string FirstLine = null;   // header to new file                  
            var writer = new StreamWriter(GetFileName(FileName, num));
            // Loop through all source lines
            foreach (var line in File.ReadLines(FilePath))
            {
                if (string.IsNullOrEmpty(FirstLine)) FirstLine = line;
                // Length of current line
                int length = line.Length;
                // See if adding this line would exceed the size threshold
                if (total + length >= size)
                {
                    // Create a new file
                    num++;
                    total = 0;
                    writer.Dispose();
                    writer = new StreamWriter(GetFileName(FileName, num));
                    writer.WriteLine(FirstLine);
                    length += FirstLine.Length;
                }
                // Write the line to the current file                
                writer.WriteLine(line);
                // Add length of line in bytes to running size
                total += length;
                // Add size of newlines
                total += Environment.NewLine.Length;
            }
