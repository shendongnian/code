    static void Main(string[] args)
    {
        int counter = 0;
        string line;
        int output;
        //Read the file 
        System.IO.StreamReader file = new System.IO.StreamReader(@"Map.txt");
        while ((line = file.ReadLine()) != null)
        {
            int.TryParse(line, out output);
            Console.WriteLine(line);
            counter = counter + 1;
            if (counter == 1)
            {
                Console.Clear();
            }
            if (counter == 21)
            {
                break;
            }
        }
    }
