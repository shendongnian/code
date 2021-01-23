    public static void ReadFromFile(string localPath) // paremetrizing the path for more flexibility
        {
            StreamReader sr = new StreamReader(localPath);
            // extrating the lines from the file
            List<int> lines = Regex.Split(sr.ReadToEnd(), "\r\n").Select(int.Parse).ToList();
            // we can close the reader as we don't need it anymore
            sr.Close();
            Console.WriteLine( lines[0] + " var1");
            Console.WriteLine( lines[1] + " var2");
            // removing the first 2 elements
            lines = lines.Skip(2).ToList();
            for (int i = 0; i < lines.Count; i++)
            {
                Console.WriteLine("item {0} = {1}", i-1, lines[i] );
            }
           
        }
