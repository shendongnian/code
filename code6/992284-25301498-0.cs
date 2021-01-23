    class Program
    {
        static readonly string filePath = "c:\\test.txt";
        static void Main(string[] args)
        {
            // Read your file
            List<string> lines = ReadLines();
            
            //Create your remove logic here ..
            lines = lines.Where(x => x.Contains("Julia Roberts") != true).ToList();
            
            // Rewrite the file
            WriteLines(lines);
            
            
        }
        static List<string> ReadLines()
        {
            List<string> lines = new List<string>();
            using (StreamReader sr = new StreamReader(new FileStream(filePath, FileMode.Open)))
            {
                while (!sr.EndOfStream)
                {
                    string buffer = sr.ReadLine();
                    lines.Add(buffer);
                    // Just to show you the results
                    Console.WriteLine(buffer); 
                }
            }
            return lines;
        }
        static void WriteLines(List<string> lines)
        {
            using (StreamWriter sw = new StreamWriter(new FileStream(filePath, FileMode.Create)))
            {
                foreach (var line in lines)
                {
                    sw.WriteLine(line);
                }
            }
        }
    }
