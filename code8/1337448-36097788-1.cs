        static void Main(string[] args)
        {
            //list to store stats
            List<string[]> pokenmonStats = new List<string[]>();
            //get a reader on the file
            using (StreamReader reader = new StreamReader("TextFile1.txt"))
            {
                //while we still have lines to read
                while (!reader.EndOfStream)
                {
                    //get the line of stats
                    string line = reader.ReadLine();
                    //split it on the ' ' character and store it in our list of pokemon stats
                    pokenmonStats.Add(line.Split(' '));
                }
            }
            //we have them all so do something, like print to screen
            foreach (string[] pokemon in pokenmonStats)
            {
                foreach (string stat in pokemon)
                    Console.Write(stat + " ");
                Console.WriteLine();
            }
            Console.ReadLine();
        }
