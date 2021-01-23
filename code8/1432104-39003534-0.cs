    public static List<files> CSVReader()
        {
            var reader = new StreamReader(File.OpenRead("C:\\PO-02.csv"));
            reader.ReadLine();
            int counter = 0;
            string line;
            System.IO.StreamReader file = new System.IO.StreamReader("C:\\PO-02.csv");
    
            // Create a list to hold your 'files' objects
            List<files> items = new List<files>();
            while ((line = file.ReadLine()) != null)
            {
                Console.WriteLine(line);
                // Add a new 'files' object to your list by passing it the split csv line
                string[] data = line.split(",");
                items.Add(new files(data));
                counter++;
            }
            file.Close();
            return items;
        }
