        public static void ReadFileAndStoreInArrayList(string file)
        {
            ArrayList FamousWords = new ArrayList();
            using (StreamReader path = new StreamReader(file))
            {
                string line;
                while ((line = path.ReadLine()) != null)
                {
                    FamousWords.Add(line);
                }
            }
            foreach (string line in FamousWords)
            {
                Console.Write(line);
            }
        }
