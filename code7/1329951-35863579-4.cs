     var formattedLines = File.ReadAllLines("C:/Temp/BOM.txt")
                    .Where(line => !string.IsNullOrEmpty(line))
                    .Select(s => s.Insert(12, "-814590")).ToArray();
    
    File.WriteAllLines(@"C:/Temp/xBOM.txt", formattedLines);
