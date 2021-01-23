            // Read the entire file
            List<string> fileLines = new List<string>();
            fileLines.AddRange(File.ReadAllLines("read.txt"));
            
            // Indexes start at 0
            fileLines.RemoveAt(9); // This is actually line 10
            fileLines.RemoveAt(18); // This is actually line 19
            // Write the entire file back out now that it has been modified
            File.WriteAllLines("read.txt", fileLines);
