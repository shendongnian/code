    using(var file = new StreamReader(@"D:\Temp\AccessOutlook.txt"))
    {
        List<string> lines = new List<string>();
        while ((line = file.ReadLine()) != null)
        {
            if (!line.Contains(myString))
            {
               lines.Add(line);
            } 
            else 
            {
                Console.WriteLine(string.Join(Environment.NewLine, lines.Concat(new[] { line })));
            }
            if(lines.Count > 6) lines.RemoveAt(0);
         }
    }
