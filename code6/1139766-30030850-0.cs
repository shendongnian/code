    public static void ReadFile(string path)
        {
            List<string> Col1 = new List<string>();
            List<string> Col2 = new List<string>();
            List<string> Col3 = new List<string>();
            using (StreamReader sr = new StreamReader(path))
            {
                while (sr.EndOfStream)
	            {
	                string header = sr.ReadLine();
                    var values = header.Split(' ');
                    Col1.Add(values[0]);
                    Col2.Add(values[1]);
                    Col3.Add(values[2]);
	            } 
            }
        }
