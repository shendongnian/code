    //Sample use
    //"infile.txt".ReadFileAsLines()
    //            .WriteAsLinesTo("outfile.txt");
    public static class ToolKit
    {
        public static IEnumerable<string> ReadFileAsLines(this string infile)
        {
            if (string.IsNullOrEmpty(infile))
                throw new ArgumentNullException("infile");
            if (!File.Exists(infile))
                throw new FileNotFoundException("File Not Found", infile);
            using (var reader = new StreamReader(infile))
                while (!reader.EndOfStream)
                    yield return reader.ReadLine();
        }
        public static void WriteAsLinesTo(this IEnumerable<string> lines, string outfile)
        {
            if (lines == null)
                throw new ArgumentNullException("lines");
            if (string.IsNullOrEmpty(outfile))
                throw new ArgumentNullException("outfile");
            using (var writer = new StreamWriter(outfile))
                foreach (var line in lines)
                    writer.WriteLine(line);
        }
    }
