        static void Main(string[] args)
        {
            string dirFolderPath = string.Format("{0}/{1}", Directory.GetCurrentDirectory(), "Itemized");
            DirectoryInfo dir = new DirectoryInfo(dirFolderPath);
            
            if(!dir.Exists)
            {
                dir.Create();
            }
            FileInfo[] files = dir.GetFiles("*.txt");
            for(int i = 0; i < files.Length; i++)
            {
                string line = string.Format("\n{0}-{1}", i, files[i].Name);
                Console.WriteLine(line);   
            }
            Console.ReadLine();
        }
