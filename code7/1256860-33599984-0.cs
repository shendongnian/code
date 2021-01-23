     List<string> formattedList = new List<string>();
            //read from .txt file
            using (StreamReader sr = new StreamReader("Source path.txt"))
            {
                string line = sr.ReadLine();
                //get index of second occurance of the ' char.
                int length = line.IndexOf("'", 2); 
                //start 2 indexes in and return the substring until second 
                //occurance of ' char
                string formattedLine = line.Substring(2, length);
                formattedList.Add(formattedLine);
            }
            //write to .txt file
            using (StreamWriter sw = new StreamWriter("Destination Path.txt"))
            {
                foreach (var line in formattedList)
                {
                    sw.WriteLine(line);
                }
            }
