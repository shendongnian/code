    static void Main(string[] args)
        {
            String directory = @"C:\Users\user\Desktop\";
            String[] linesA = File.ReadAllLines(Path.Combine(directory, "Database.txt"));
            String[] linesB = File.ReadAllLines(Path.Combine(directory, "Slave.txt"));
            IEnumerable<String> onlyB = linesA.Where(x=>linesB.Contains(x.Substring(x.IndexOf(". "+1))));
            File.WriteAllLines(Path.Combine(directory, "Result.txt"), onlyB);
        }
