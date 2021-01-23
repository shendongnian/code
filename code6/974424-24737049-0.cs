    class Program
    {
        static void Main(string[] args)
        {
            var allLines = File.ReadLines("file.txt");
           List<string> list =  new List<string>();
            foreach (var line in allLines)
            {
                
                if (line.Contains("n/a"))
                {
                    var newLine = line.Replace(",n/a,", string.Empty); 
                    list.Add(newLine);
                     list.Add(line.PadLeft(line.Length+2,'/'));
                }
                else
                {
                    list.Add(line);
                }
               
            }
            File.WriteAllLines("newFile.txt",list);
        }
    }
