            StreamReader inputFile = new StreamReader(File.OpenRead("c:\\bigfile.csv"));
            StreamWriter outputFile = new StreamWriter(File.OpenWrite("c:\\smallfile.csv"));
            Random rand = new Random(Guid.NewGuid().GetHashCode());
            int rowCount = 0;
            int rowsUsed = 0;
            skipCount = rnd.Next(1, 2000);
            while(rowsUsed < 100000)
            {
             while(!inputFile.EndOfStream || rowsUsed > 100000)
             {
                string line = inputFile.ReadLine();
                if (rowCount % skipCount == 1)
                {
                    outputFile.WriteLine(line);
                    skipCount = rnd.Next(1, 2000);
                }
                rowCount++;
             }
             StreamReader inputFile = new StreamReader(File.OpenRead("c:\\bigfile.csv"));
            }
