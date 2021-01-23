     string[] lines = System.IO.File.ReadAllLines(@"D:\textfile.txt");
            foreach (string line in lines)
            {
                Console.WriteLine(line);
            }
