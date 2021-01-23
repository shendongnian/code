    public static List<string[]> CSVReader()
    {
        using (var reader = new StreamReader(File.OpenRead("C:\\PO-02.csv"))
        {
            var csv = new List<string[]>();
            reader.ReadLine();
            int counter = 0;
            string line;
            using (StreamReader file = new StreamReader("C:\\PO-02.csv"))
            {
                while ((line = file.ReadLine()) != null)
                {
                    list.Add(line.Split(','))
                    counter++;
                }
            }
            return list;
         }
    }
