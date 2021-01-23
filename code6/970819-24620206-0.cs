    static void Main(string[] args)
    {
        var details = ReadDetail("data.txt").ToArray();
        var classValues = Enumerable.Range(0, 10).ToArray();
    
        foreach (var classValue in classValues)
        {
            // Create file/directory etc
    
            using (var file = new StreamWriter("out.txt"))
            {
                foreach (var detail in details)
                {
                    file.WriteLine("{0} {1}", detail.Classes.Contains(classValue) ? "+1" : "-1", detail.Line);
                }
            }
        }
    }
    
    static IEnumerable<Detail> ReadDetail(string filePath)
    {
        using (StreamReader reader = new StreamReader(filePath))
        {
            while (!reader.EndOfStream)
            {
                string line = reader.ReadLine();
                int separator = line.IndexOf(' ');
    
                Detail detail = new Detail
                {
                    Classes = line.Substring(0, separator).Split(',').Select(c => Int32.Parse(c)).ToArray(),
                    Line = line.Substring(separator + 1)
                };
    
                yield return detail;
            }
        }
    }
    
    public class Detail
    {
        public int[] Classes { get; set; }
        public string Line { get; set; }
    }
