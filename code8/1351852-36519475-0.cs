            string file = @"C:\temp\testfile.txt";
            List<string> lines = new List<string>();
            string line = "";
            using (StreamReader reader = new StreamReader(file))
            {
                while ((line = reader.ReadLine()) != null)
                {
                    lines.Add(line);
                }
                listBox1.DataSource = (lines);
            }
