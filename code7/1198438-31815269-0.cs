        List<String> Folders = new List<string>();
        private void button1_Click(object sender, EventArgs e)
        {
            string path = @"C:\Users\mikes\Documents\SomeFile.txt";
            string folderTag = "folder=";
            using (FileStream fss = new FileStream(path, FileMode.Open))
            {
                using (StreamReader sr = new StreamReader(fss))
                {
                    while (!sr.EndOfStream)
                    {
                        string line = sr.ReadLine();
                        if (line.StartsWith(folderTag))
                        {
                            line = line.Substring(folderTag.Length); // remove the folderTag from the beginning
                            Folders.AddRange(line.Split(";".ToCharArray(), StringSplitOptions.RemoveEmptyEntries));
                        }
                    }
                }
            }
            foreach(string folder in Folders)
            {
                Console.WriteLine(folder);
            }
        }
